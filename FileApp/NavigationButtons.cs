using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileApp
{
    public class NavigationButtons
    {
        List<Button> buttons;
        Color defaultColor;
        Color selectedColor;

        public NavigationButtons(List<Button> buttons, Color defaultColor, Color selectedColor)
        {
            this.buttons = buttons;
            this.defaultColor = defaultColor;
            this.selectedColor = selectedColor;
        }

        private void SetButtonColor()
        {
            foreach(var button in buttons)
            {
                button.BackColor = defaultColor;
            }
        }

        public void Highlight(Button selectedButton)
        {
            foreach(var button in buttons)
            {
                if(button == selectedButton)
                {
                    selectedButton.BackColor = selectedColor;
                } else
                {
                    button.BackColor=defaultColor;
                }
            }
        }
    }
}
