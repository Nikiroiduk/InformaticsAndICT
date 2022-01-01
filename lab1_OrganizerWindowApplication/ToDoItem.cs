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
        public States State { get; private set; }
        public string Date { get; private set; }
        public string Time { get; private set; }
        public string Name { get; private set; }
        public Types Type { get; private set; }
        public string Content { get; private set; }

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

            this.Name = Name;
            this.Type = Type;
            this.Date = String.Format("{0:d2}/{1:d2}/{2:d2}", Date.Day, Date.Month, Date.Year);
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
    }
}
