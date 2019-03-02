using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Блок №1. Абстрактные классы и виртуальные методы.
//Использование Абстрактных классов и витруальных методо продемонстрировано на основе паттерна "Абстрактная фабрика"

namespace Lab1
{
    //Создание Абстрактного класса - "AbstractSport". Его метода - ""
    abstract class AbstractSport
    {
        public abstract void Inventory();
    }

    abstract class AbstractAction
    {
        public abstract void Action();
    }

    abstract class AbsractPosition
    {
        public virtual void PlayerPosition()
        {
            Console.WriteLine("Здесь будет ваша позиция");
        }
    }

    class Football : AbstractSport
    {
        public override void Inventory()
        {
            Console.WriteLine("Футбольный мяч!");
        }
    }

    class Hockey : AbstractSport
    {
        public override void Inventory()
        {
            Console.WriteLine("Клюшка");
        }
    }

    class Volleyball : AbstractSport
    {
        public override void Inventory()
        {
            Console.WriteLine("Волейбольный мяч");
        }
    }

    class Hit : AbstractAction
    {
        public override void Action()
        {
            Console.WriteLine("Бей!");
        }
    }

    class Conducting: AbstractAction
    {
        public override void Action()
        {
            Console.WriteLine("Веди!");
        }
    }

    class Defense : AbstractAction
    {
        public override void Action()
        {
            Console.WriteLine("Защищайся!");
        }
    }

    class Attack : AbsractPosition
    {
        public override void PlayerPosition()
        {
            Console.WriteLine("Нападающий");
        }
        
    }

    class Defender : AbsractPosition
    {
        public override void PlayerPosition()
        {
            Console.WriteLine("Защитник");
        }
    }

    class Support : AbsractPosition
    {
        public override void PlayerPosition()
        {
            Console.WriteLine("Поддержка");
        }
    }

    abstract class AbstractFactory
    {
        public abstract AbstractSport CreateSport();
        public abstract AbstractAction CreateAction();
        public abstract AbsractPosition CreatePosition();
    }

    class FootballFactory: AbstractFactory
    {
        public override AbstractSport CreateSport()
        {
            return new Football();
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

    class VolleyballFactory: AbstractFactory
    {
        public override AbstractSport CreateSport()
        {
            return new Volleyball();
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

    class HockeyFactory: AbstractFactory
    {
        public override AbstractSport CreateSport()
        {
            return new Hockey();
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

    class Playground
    {
        public Playground(AbstractFactory factory)
        {
            _factory = factory;
        }

        private AbstractFactory _factory;

        public void InitiateGame() {
            AbstractSport sport = _factory.CreateSport();
            AbstractAction action = _factory.CreateAction();
            AbsractPosition position = _factory.CreatePosition();
            Console.WriteLine("Твой инвентарь: ");
            sport.Inventory();
            Console.WriteLine("Твое действие: ");
            action.Action();
            Console.WriteLine("Твоя позиция");
            position.PlayerPosition();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FootballFactory factory = new FootballFactory();
            Playground playground = new Playground(factory);
            playground.InitiateGame();

            Console.ReadKey();
        }
    }
}
