﻿using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

//Поля
//Работает по той же логике, которую мы реализовали на прошлом уроке — в помеченное атрибутом Inject
//поле устанавливается экземпляр этого типа из контекста.
public class ClassWithInjectedFields
{
    [Inject] private ICommand _instance;
}
//Конструктор
//Когда экземпляр создаётся фреймворком, последний может передать в его конструктор необходимые объекты.
//Для этого достаточно пометить атрибутом Inject конструктор класса:
//В этом случае фреймворк передаст в конструктор экземпляр типа, реализующего ICommand.
public class ClassWithInjectedContructor
{
    [Inject]
    public ClassWithInjectedContructor(ICommand instance)
    {

    }
}
//Свойства
//Мы также можем прокидывать зависимости в свойства:
//Фреймворк воспользуется сеттером свойства и передаст
//в параметры экземпляр соответствующего типа.
public class ClassWithInjectedProperties
{
    [Inject]
    public ICommand Instance
    {
        get;
        private set;
    }
}
//Методы
//Наконец, мы можем воспользоваться методом. Достаточно пометить атрибутом Inject метод,
//и он будет вызван во время инициализации экземпляра, а фреймворк передаст ему нужные параметры из контекста:
public class ClassWithInjectedMethod
{
    [Inject]
    public void Init(ICommand instance)
    {

    }
}
//ZenjectBinding
//Компонент ZenjectBinding — простейший пример инсталлера.
//По своей логике работы он в чём-то похож на тот, что делали мы.
//В том смысле, что ZenjectBinding позволяет получать лишь те объекты,
//которые уже существуют в этом же графе и обеспечивать простейшую логику уточнения.
//А именно:
//Присвоить объектам идентификатор (поле Identifier), которым затем можно пользоваться в атрибутах так же
//, как мы пользовались именем ассета в нашем атрибуте InjectAsset. Выглядит это так:
public class Bar1
{
    [Inject(Id = "foo")]
    ICommand _foo;
}
//Можно настроить тип байндинга с помощью поля BindType. Это контролирует логику привязки данных экземпляров к полям.
//В нашем мини-фреймворке мы реализовали такую логику:
//если тип объекта можно привести к типу поля, идёт пробрасывание объекта в это поле.
//В этом же случае у нас есть целых 4 варианта логики:
//Self — будут затронуты только те поля, в которых тип точно соответствует типу объекта.  
//BaseType — только поля с базовым типом для типа объекта.
//AllInterfaces — только поля с интерфейсами, реализуемыми данным объектом. 
//AllInterfacesAndSelf - пункты «‎a» и «‎c» вместе.

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        //Container.Bind<Greeter>().AsSingle().NonLazy();
    }
}
//У предыдущего компонента была ограниченная функциональность.
//Этот даёт нам более полную.
//Но чтобы пользоваться ей, мы должны отнаследоваться от данного класса.
//Вся логика связывания прописывается в переопределённом методе InstallBingings:
//Как видите, мы используем linq-подобный синтаксис для настройки логики привязки. Разберём, что тут происходит:
//Container — экземпляр класса DiContainer, который является главным классом, обеспечивающим функциональность IoC-контейнера.
//Он контролирует создание графа объектов и их инициализацию. Подробнее об этом классе поговорим потом.
//Метод Bind задаёт тип, который мы будем в дальнейшем связывать с экземпляром.
//FromInstance указывает экземпляр объекта, который мы будем привязывать к определённому типу.
//AsSingle говорит контейнеру, что ему нужно обеспечить наличие экземпляра в единственном числе.
//NonLazy говорит контейнеру создать экземпляр тут же, а не по требованию.

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
