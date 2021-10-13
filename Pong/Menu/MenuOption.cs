using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Menu
{
    class MenuOption // Could be struct, but text might change
    {
        public delegate void Action();

        public String Text { get; }
        private Action action;
        public MenuOption(String text, Action action)
        {
            this.Text = text;
            this.action = action;
        }
        
        public void Execute()
        {
            action();
        }
    }
}
