using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Cat cat = new Cat("梦美猫");

            MessageBox.Show(cat.Shout());//子类继承父类的shout方法 调用时因为重构了方法，因此调用子类的getshoutsound
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dog dog = new Dog("魅魔狗");
            MessageBox.Show(dog.Shout());
        }

        //private Animal[] arrayanimal; //数组备用(选用泛型集合替换)

        List<Animal> arrayAnimal;//集合加强版 泛型 指定集合为Animal类型
        private void button3_Click(object sender, EventArgs e)
        {

            //arrayanimal = new Animal[3];
            //arrayanimal[0] = new Cat("梦美猫");
            //arrayanimal[1] = new Dog("魅魔狗");
            //arrayanimal[2] = new Sheep("神绮羊");
            arrayAnimal = new List<Animal>();
            arrayAnimal.Add(new Cat("梦美猫"));
            arrayAnimal.Add(new Cat("魅魔狗"));
            arrayAnimal.Add(new Cat("神绮羊"));
            MessageBox.Show("报名成功");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Animal item in arrayAnimal)
            {
                MessageBox.Show(item.Shout());//数组类型为animal 想叫animal类必须有方法 而父类方法不能确定多只动物哪只分别叫什么，于是使用多态（一种类型 多种状态）解决，子类重写父类的shout就可以分辨了 (父类方法不能确认多种状态)
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SuperCat supercat = new SuperCat("超级梦美猫");
            SuperDog superdog = new SuperDog("超级神绮狗");

            Ichange[] ChangeArray = new Ichange[2];
            ChangeArray[0] = supercat;
            ChangeArray[1] = superdog;
            foreach (Ichange itm in ChangeArray)
            {
                MessageBox.Show(itm.ChangeThing("各种各样的东西"));
            }
        }
    }

    class Animal
    {
        protected string name = "";
        protected int shoutnum = 3;
        public string Shout()
        {
            string result = "";

            for (int i = 0; i < shoutnum; i++)
            {
                result += getShoutSound();//调用的为Cat子类的getshoutSound方法
            }

            return "我的名字是" + name + result;
        }

        public Animal(string Name)
        {
            this.name = Name;
        }
        public Animal()
        {
            this.name = "无名";
        }
        public int Shoutnum { get { return shoutnum; } set { shoutnum = value; } }



        public virtual string getShoutSound()
        {
            return "";
        }

    }
    interface Ichange
    {
        string ChangeThing(string thing);
    }
    



    class Cat : Animal
    {
        public Cat(string Name) : base(Name) { }//base调用父类的构造方法 而Cat传参相当于base调用父类的方法传参

        public override string getShoutSound()
        {
            return "喵";
        }
    }

    class Dog : Animal
    {
        public Dog(string Name) : base(Name) { }
        public override string getShoutSound()
        {
            return "旺";
        }

    }

    class Sheep : Animal
    {
        public Sheep(string Name) : base(Name) { }
        public override string getShoutSound()
        {
            return "咩";
        }
    }

    class SuperCat : Cat, Ichange
    {
        public SuperCat(string Name) : base(Name) { }

        public override string getShoutSound()
        {
            return "喵";
        }

        public string ChangeThing(string thing)
        {
            return base.Shout() + "我能变出:" + thing;
        }
    }

    class SuperDog : Dog, Ichange
    {
        public SuperDog(string Name) : base(Name) { }

        

        public string ChangeThing(string thing)
        {
            return base.Shout() + "我能变出:" + thing;
        }
    }
}
