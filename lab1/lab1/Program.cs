using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //АБСТРАКТНИЙ БАЗОВИЙ КЛАС
    abstract class MusicalInstrument
    {
        protected string name;
        protected string characteristics;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Characteristics
        {
            get => characteristics;
            set => characteristics = value;
        }

        public MusicalInstrument()
        {
            name = "Unknown";
            characteristics = "None";
        }

        public MusicalInstrument(string name)
        {
            this.name = name;
            this.characteristics = "General characteristics";
        }

        public MusicalInstrument(string name, string characteristics)
        {
            this.name = name;
            this.characteristics = characteristics;
        }

        public MusicalInstrument(MusicalInstrument other)
        {
            this.name = other.name;
            this.characteristics = other.characteristics;
        }

        public abstract void Sound();
        public abstract void Show();
        public abstract void Desc();
        public abstract void History();

        public virtual void ShowInfo()
        {
            Show();
            Console.WriteLine($"Характеристики: {characteristics}");
            Desc();
            History();
            Console.Write("Звук: ");
            Sound();
            Console.WriteLine(new string('-', 30));
        }
    }

    //ПОХІДНІ КЛАСИ

    class Violin : MusicalInstrument
    {
        public Violin() : base("Скрипка", "Струнно-смичковий інструмент") { }
        public Violin(string name, string chars) : base(name, chars) { }
        public Violin(Violin other) : base(other) { }

        public override void Sound() => Console.WriteLine("Ті-лі-лі, віу-віу...");
        public override void Show() => Console.WriteLine($"Інструмент: {name}");
        public override void Desc() => Console.WriteLine("Опис: Має чотири струни, високий регістр.");
        public override void History() => Console.WriteLine("Історія: З'явилася у сучасному вигляді в Італії XVI століття.");
    }

    class Trombone : MusicalInstrument
    {
        public Trombone() : base("Тромбон", "Мідний духовий інструмент") { }
        public Trombone(string name, string chars) : base(name, chars) { }
        public Trombone(Trombone other) : base(other) { }

        public override void Sound() => Console.WriteLine("Па-па-па-пааам (низький бас)!");
        public override void Show() => Console.WriteLine($"Інструмент: {name}");
        public override void Desc() => Console.WriteLine("Опис: Має рухому кулісу для зміни висоти звуку.");
        public override void History() => Console.WriteLine("Історія: Походить від труби, відомий з XV століття.");
    }

    class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Укулеле", "Гавайська гітара") { }
        public Ukulele(string name, string chars) : base(name, chars) { }
        public Ukulele(Ukulele other) : base(other) { }

        public override void Sound() => Console.WriteLine("Плінь-плянь (легкий тропічний звук).");
        public override void Show() => Console.WriteLine($"Інструмент: {name}");
        public override void Desc() => Console.WriteLine("Опис: Маленька чотириструнна гітара.");
        public override void History() => Console.WriteLine("Історія: Потрапила на Гаваї з Португалії наприкінці XIX ст.");
    }

    class Cello : MusicalInstrument
    {
        public Cello() : base("Віолончель", "Великий струнно-смичковий інструмент") { }
        public Cello(string name, string chars) : base(name, chars) { }
        public Cello(Cello other) : base(other) { }

        public override void Sound() => Console.WriteLine("Глибокий, оксамитовий низький звук.");
        public override void Show() => Console.WriteLine($"Інструмент: {name}");
        public override void Desc() => Console.WriteLine("Опис: Більша за скрипку, грають сидячи.");
        public override void History() => Console.WriteLine("Історія: Стала популярною у XVII столітті.");
    }

    //ГОЛОВНИЙ КЛАС
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MusicalInstrument[] orchestra = new MusicalInstrument[4];

            orchestra[0] = new Violin();
            orchestra[1] = new Trombone("Професійний тромбон", "Латунь, золоте покриття");
            orchestra[2] = new Ukulele();
            orchestra[3] = new Cello();

            Console.WriteLine("ОРКЕСТР ПРЕДСТАВЛЯЄ ІНСТРУМЕНТИ\n");
            foreach (var instrument in orchestra)
            {
                instrument.ShowInfo();
            }

            Violin originalViolin = new Violin("Старовинна скрипка", "Дерево, майстер Страдіварі");
            Violin copyViolin = new Violin(originalViolin);

            Console.WriteLine("Демонстрація копії об'єкта:");
            copyViolin.ShowInfo();

            Console.ReadKey();
        }
    }
}
