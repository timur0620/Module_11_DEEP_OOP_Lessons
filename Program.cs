using System.Collections;

namespace Module_11_DEEP_OOP_Lessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    class Robot : IEquatable<Robot>
    {
        private string dislocation;
        public string Dislocation { get { return dislocation; } }

        public string Nickname { get; set; }

        public Robot(string Nickname, string Dislocation)
        {
            this.Nickname = Nickname;
            this.dislocation = Dislocation;
        }
        public bool Equals(Robot other)
        {
            return this.Nickname == other.Nickname && this.dislocation == other.dislocation;

        }
    }
    class Cat : IComparable 
    {
        private int id { get; set; }
        private string dislocation;
        public string Dislocation { get { return dislocation; } }
        public string Nickname { get; set; }
        public string Color { get; set; }


        public Cat(int id, string Nickname, string Dislocation, string color)
        {   
            this.id = id;
            this.Nickname = Nickname;
            this.dislocation = Dislocation;
            Color = color;  
        }
        public int CompareTo(object obj)
        {
            var other = (Cat)obj;   
            if (this.id > other.id) return 1;
            else if (this.id < other.id) return -1;
            else return 0;
        }
    }
    class Dog 
    {
        public int id { get; set; }
        private string dislocation;
        public string Dislocation { get { return dislocation; } }
        public string Nickname { get; set; }
        public string Color { get; set; }
        public Dog(int id, string Nickname, string Dislocation, string color)
        {
            this.id = id;
            this.Nickname = Nickname;
            this.dislocation = Dislocation;
            this.Color = color;
        }

    }
    class StaticDog
    {   
        private static int staticID;
        static StaticDog () { staticID = 0; }
        private static int NextId()
        {
            staticID++;
            return staticID;
        }
        public int id { get; set; }
        private string dislocation;
        public string Dislocation { get { return dislocation; } }
        public string Nickname { get; set; }
        public string Color { get; set; }
        public StaticDog(int id, string Nickname, string Dislocation, string color)
        {
            this.id = StaticDog.NextId();
            this.Nickname = Nickname;
            this.dislocation = Dislocation;
            this.Color = color;
        }

    }
    class Repository : ICloneable, IEnumerable
    {
        public List<Dog> listDog { get; set; }
        public Dog[] massiveDog;
        public Dog this[int index]
        {
            get { return this.massiveDog[index]; }
        }
        public Dog this[string nickName]
        {
            get
            {
                Dog dog = null;
                foreach (var item in massiveDog)
                {
                    if (item.Nickname == nickName)
                    {
                        dog = item; break;
                    }
                }
                return dog;
            }
        }
        public Repository(int count)
        {

        }
        public object Clone()
        {
            var data = new Repository(10);

            foreach (var item in listDog)
            {
                data.listDog.Add(new Dog(item.id, item.Nickname, item.Dislocation, item.Color));
            }
            return data;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < listDog.Count; i++)
            {
                yield return listDog[i];
            }
        }

    }
}
