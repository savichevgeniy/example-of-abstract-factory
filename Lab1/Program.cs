using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Блок №1. Абстрактные классы и виртуальные методы.
//Использование Абстрактных классов и витруальных методо продемонстрировано на примере паттерна "Абстрактная фабрика"
//Предметная область - спорт. Спорт может быть различного вида, иметь различные действия и гапример позиции.
//На основе этого, в данном примере, создана "Абстрактная фабрика"- Спорт.

namespace Lab1
{
    //Создание Абстрактного класса - "AbstractInventory" - базовый для видов спорта.
    abstract class AbstractInventory
    {
        //Создание абстрактного метода. Такой метод является обязательным для использования в дочернем классе.
        public abstract void Item();
    }
    //Создание Абстрактного класса - "AbstractAction" - базовый для действий.
    abstract class AbstractAction
    {
        public abstract void Action();
    }
    //Создание Абстрактного класса - "AbsractPosition" - базовый для позиций игроков.
    abstract class AbsractPosition
    {
        //Создаем виртуального метода - содержащего вывод позиции игрока.
        //Виртуальный метод может не использоваться в дочернем классе, в отличии от абстрактного.
        //На данном примере также будет продемонстрированно ранне (статическая) и позднее (динамическая) связывание (типизация)
        public virtual void PlayerPosition()
        {
            Console.WriteLine("Нападающий!");
        }
    }
    //Дочерний класс, который служит для задания конкретного инвентаря (фетбольного)
    class FootballInventory : AbstractInventory
    {
        public override void Item()
        {
            Console.WriteLine("Футбольный мяч!");
        }
    }
    //Дочерий класс, который служит для задания хоккейного инвентаря
    class HockeyInventory : AbstractInventory
    {
        public override void Item()
        {
            Console.WriteLine("Клюшка!");
        }
    }
    //Дочерий класс, который служит для задания волейбольного инвентаря
    class VolleyballInventory : AbstractInventory
    {
        public override void Item()
        {
            Console.WriteLine("Волейбольный мяч");
        }
    }
    //Дочерий класс, который служит для задания конкретного действия - удар.
    class Hit : AbstractAction
    {
        public override void Action()
        {
            Console.WriteLine("Бей!");
        }
    }
    //Дочерий класс, который служит для задания конкретного действия - ведение.
    class Conducting : AbstractAction
    {
        public override void Action()
        {
            Console.WriteLine("Веди!");
        }
    }
    //Дочерий класс, который служит для задания конкретного действия - защита.
    class Defense : AbstractAction
    {
        public override void Action()
        {
            Console.WriteLine("Защищайся!");
        }
    }
    //Дочерий класс, который служит для задания действия - нападающий.
    class Attack : AbsractPosition
    {
        //Раннее связывание. Использование метода, базового класса, для заданаия позиции - нападающий.
        public new void PlayerPosition()
        {
        }

    }
    //Дочерий класс, служащий для задании позиции - защитник.
    class Defender : AbsractPosition
    {
        //Позднее связывание. Переопределение метода для заданаия позиции - защитник.
        public override void PlayerPosition()
        {
            Console.WriteLine("Защитник!");
        }
    }
    //Дочерий класс, служащий для задании позиции - поддержка.
    class Support : AbsractPosition
    {
        //Переопределение метода для заданаия позиции - поддержка.
        public override void PlayerPosition()
        {
            Console.WriteLine("Поддержка!");
        }
    }
    //Создание абстрактного класса служащего для реализации конкретного описания спорта.
    abstract class AbstractFactory
    {
        //Абстрактные методы реализации конкретных парамметров описания вида спорта. 
        public abstract AbstractInventory CreateInventory();
        public abstract AbstractAction CreateAction();
        public abstract AbsractPosition CreatePosition();
    }
    //Дочерий класс служащий для реализации конкретного спорта - футбол.
    class FootballFactory : AbstractFactory
    {
        //Создание функций возвращающих конретные параметры для футбола.
        public override AbstractInventory CreateInventory()
        {
            return new FootballInventory();
        }
        public override AbstractAction CreateAction()
        {
            return new Hit();
        }
        public override AbsractPosition CreatePosition()
        {
            return new Attack();
        }
    }
    //Дочерий класс служащий для реализации конкретного  вида спорта - волейбол.
    class VolleyballFactory : AbstractFactory
    {
        //Создание функций возвращающих конретные параметры для волейбола.
        public override AbstractInventory CreateInventory()
        {
            return new VolleyballInventory();
        }
        public override AbstractAction CreateAction()
        {
            return new Defense();
        }
        public override AbsractPosition CreatePosition()
        {
            return new Defender();
        }
    }
    //Дочерий класс служащий для задания спорта - хоккей.
    class HockeyFactory : AbstractFactory
    {
        //Создание функций возвращающих конретные параметры для хоккея.
        public override AbstractInventory CreateInventory()
        {
            return new HockeyInventory();
        }
        public override AbstractAction CreateAction()
        {
            return new Conducting();
        }
        public override AbsractPosition CreatePosition()
        {
            return new Support();
        }
    }
    //создание класса служащего для вывода спорта
    class Playground
    {
        //Создание конструктора для вывода конкретного экземпляра спорта
        public Playground(AbstractFactory factory)
        {
            _factory = factory;
        }

        private AbstractFactory _factory;
        //Функция для реализации конкретного вида спорта.
        public void InitiateGame()
        {
            AbstractInventory sport = _factory.CreateInventory();
            AbstractAction action = _factory.CreateAction();
            AbsractPosition position = _factory.CreatePosition();
            Console.Write("Твой инвентарь: ");
            sport.Item();
            Console.Write("Твое действие: ");
            action.Action();
            Console.Write("Твоя позиция: ");
            position.PlayerPosition();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            //Демонстрация вызова функции на конкретном примере - футбол.
            FootballFactory footballFactory = new FootballFactory();
            Playground playground = new Playground(footballFactory);
            playground.InitiateGame();
            Console.WriteLine("____________________________________");
            //Демонстрация вызова функции на конкретном примере - футбол.
            HockeyFactory hockeyFactory = new HockeyFactory();
            playground = new Playground(hockeyFactory);
            playground.InitiateGame();
            Console.ReadKey();
        }
    }
}