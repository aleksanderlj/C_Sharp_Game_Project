using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Menu
{
    class ListMenu
    {
        public List<MenuOption> Options { get; }
        public int Index { get; private set; }

        public ListMenu()
        {
            this.Index = 0;
            Options = new List<MenuOption>();
        }

        public void Down()
        {
            Index++;
            if(Index >= Options.Count)
            {
                Index = 0;
            }
        }

        public void Up()
        {
            Index--;
            if(Index < 0)
            {
                Index = Options.Count - 1;
            }
        }

        public void AddOption(MenuOption menuOption)
        {
            Options.Add(menuOption);
        }

        public void Choose()
        {
            Options[Index].Execute();
        }
    }
}
