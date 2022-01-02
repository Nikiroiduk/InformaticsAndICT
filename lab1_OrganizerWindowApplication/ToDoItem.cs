using System;

namespace lab1_OrganizerWindowApplication
{
    public enum Types
    {
        Task = 0,
        Meeting,
        Memo
    }

    public enum States
    {
        Active = 0,
        Completed
    }

    [Serializable]
    public class ToDoItem
    {
        public States State { get;  set; }
        public string Date { get;  set; }
        public string Time { get;  set; }
        public string Name { get;  set; }
        public Types Type { get;  set; }
        public string Content { get;  set; }

        private DateTime SettedDate { get; set; }

        public ToDoItem()
        {

            this.Date = String.Format("{0:d2}/{1:d2}/{2}", SettedDate.Day, SettedDate.Month, SettedDate.Year);
            this.Time = String.Format("{0:d2}:{1:d2}", SettedDate.Hour, SettedDate.Minute);
        }

        public ToDoItem(string Name, Types Type, DateTime Date, States State, string Content)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException($"'{nameof(Name)}' cannot be null or empty.", nameof(Name));
            }

            if (string.IsNullOrEmpty(Content))
            {
                throw new ArgumentException($"'{nameof(Content)}' cannot be null or empty.", nameof(Content));
            }

            this.SettedDate = Date;
            this.Name = Name;
            this.Type = Type;
            this.Date = String.Format("{0:d2}/{1:d2}/{2}", Date.Day, Date.Month, Date.Year);
            this.State = State;
            this.Content = Content;
            this.Time = String.Format("{0:d2}:{1:d2}",Date.Hour, Date.Minute);
        }

        public void setState(States State)
        {
            this.State = State;
        }

        public void setName(string Name)
        {
            this.Name = Name;
        }

        public void setType(Types Type)
        {
            this.Type = Type;
        }

        public void setContent(string Content)
        {
            this.Content = Content;
        }

        public DateTime getDate()
        {
            return SettedDate;
        }
    }
}
