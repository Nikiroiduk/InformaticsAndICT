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
        public BindingList<ToDoItem> ToDoS { get; set; }
        private List<ToDoItem> meh { get; set; }
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

            var flag = true;
            for (int i = 0; i < ToDoS.Count; i++)
            {
                if (ToDoS[i].getDate() > Date)
                {
                    flag = false;
                    ToDoS.Insert(i, new ToDoItem(Name, Type, Date, State, Content));
                    break;
                }
            }
            if (flag)
                ToDoS.Add(new ToDoItem(Name, Type, Date, State, Content));
            
            
            //backing = new List<MyClass>();
            //bl = new BindingList<MyClass>(backing);
            //var tmp = ToDoS;
            //var sorted = from todo in ToDoS
            //             orderby todo.
            //             descending
            //             select todo;
        }

        private void SortBindingList()
        {
            meh.Sort((ToDoItem X, ToDoItem Y) => X.Time.CompareTo(Y.Time));
            ToDoS.ResetBindings();
        }

        public void removeAt(int index)
        {
            ToDoS.RemoveAt(index);
        }
    }
}
