using System;

namespace lab3_Copywriter
{
    class logItem
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }
        private DateTime time { get; set; }
        public logItem(string Name, string Text, DateTime time, int Width, int Height)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException($"'{nameof(Name)}' cannot be null or empty.", nameof(Name));
            }

            if (string.IsNullOrEmpty(Text))
            {
                throw new ArgumentException($"'{nameof(Text)}' cannot be null or empty.", nameof(Text));
            }

            this.Name = Name;
            this.time = time;
            this.Text = $"{Text} [{time.Hour}:{time.Minute}]";
            this.Width = Width;
            this.Height = Height;
        }
    }
}
