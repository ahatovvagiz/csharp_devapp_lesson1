/*Доработайте приложение генеалогического дерева таким образом чтобы программа выводила на экран близких родственников (жену/мужа). Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.*/

public class Person
{
    public string Name { get; set; }
    public Person Spouse { get; set; }
    public List<Person> Children { get; set; }

    public Person(string name)
    {
        Name = name;
        Children = new List<Person>();
    }

    public void AddSpouse(Person spouse)
    {
        Spouse = spouse;
        spouse.Spouse = this;
    }

    public void AddChild(Person child)
    {
        Children.Add(child);
    }

    public void PrintFamilyTree(string prefix = "")
    {
        Console.WriteLine(prefix + "└─" + Name);
        if (Spouse != null)
        {
            Console.WriteLine(prefix + "   ├─" + Spouse.Name);
        }
        foreach (var child in Children)
        {
            child.PrintFamilyTree(prefix + "   │");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Person person1 = new Person("Grandpa");
        Person person2 = new Person("Grandma");

        Person person3 = new Person("Aunt");
        Person person4 = new Person("Mother");
        //Person person5 = new Person("Jane3");
        //Person person6 = new Person("Jane4");

        Person child1 = new Person("Father");
        Person child2 = new Person("Uncle");

        Person child3 = new Person("Son");
        Person child4 = new Person("Daughter");

        Person child5 = new Person("Сousin");
        Person child6 = new Person("Сousin2");

        person1.AddSpouse(person2);
        person1.AddChild(child1);
        person1.AddChild(child2);

        child1.AddSpouse(person4);
        child1.AddChild(child4);
        child1.AddChild(child3);

        child2.AddSpouse(person3);
        child2.AddChild(child5);
        child2.AddChild(child6);

        //person5.AddChild(child5);
        //person6.AddChild(child6);

        person1.PrintFamilyTree();
    }
}