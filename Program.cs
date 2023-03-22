using System;


namespace a
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            while (choice < 4)
            {
                Console.WriteLine("enter choice \n1=>insert data in database\n\n2=>delete data using userId\n\n3=>to update phone number\n\n4=>EXIT");
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter user id ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Name ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Phone number ");
                    string phone = Console.ReadLine();

                    if (Program.insertdata(id, name, phone))
                    {
                        Console.WriteLine("Inserted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("not inserted");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter user id ");
                    int id = int.Parse(Console.ReadLine());
                    if (Program.deleteuser(id))
                    {
                        Console.WriteLine("{0} id is deleted", id);
                    }
                    else
                    {
                        Console.WriteLine("Not found");

                    }
                }
                else if (choice == 3)
                {
                    if (Program.updatedetails())
                    {
                        Console.WriteLine("Updated");
                    }
                    else
                    {
                        Console.WriteLine("not updated");
                    }
                }

            }
        }
        public static bool insertdata(int id, string name, string phonenum)
        {
            var cont = new userEntity();
            var user = new user
            {
                UserId = id,
                Name = name,
                Phone = phonenum
            };
            var response = cont.users.Add(user);
            Console.WriteLine(response.ToString());
            try
            {
                cont.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        //end of insert method
        public static bool deleteuser(int id)
        {
            using (var context = new userEntity())
            {
                var userToDelete = context.users.Find(id);

                if (userToDelete != null)
                {
                    context.users.Remove(userToDelete);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //end of deleteuser method

        public static bool updatedetails()
        {

            using (var context = new userEntity())
            {
                Console.WriteLine("enter userId to update ");
                int userId = int.Parse(Console.ReadLine());
                Console.WriteLine("enter new phone number ");
                string newPhoneNumber = Console.ReadLine();

                var userToUpdate = context.users.Find(userId);

                if (userToUpdate != null)
                {
                    userToUpdate.Phone = newPhoneNumber;
                    context.SaveChanges();
                    return true;
                }
                else
                { return false; }
            }
        }
    }
}