using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace lab1_OrganizerWindowApplication
{
    [Serializable]
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public BindingList<ToDoItem> ToDoS { get; private set; }
        public User(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentException($"'{nameof(login)}' cannot be null or empty.", nameof(login));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
            }

            this.Login = login;
            this.Password = password;
        }

        public void addToDo(string Name, Types Type, DateTime Date, States State, string Content)
        {
            if (ToDoS == null)
                ToDoS = new BindingList<ToDoItem>();
            ToDoS.Add(new ToDoItem(Name, Type, Date, State, Content));
        }

        public void removeAt(int index)
        {
            ToDoS.RemoveAt(index);
        }
    }
}
