using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileApp
{
    public class NavigationControls
    {
        List<UserControl> userControls = new List<UserControl>();
        Panel panel;

        public NavigationControls(List<UserControl> userControls, Panel panel)
        {
            this.userControls = userControls;
            this.panel = panel;
            AddUserControls();
        }

        private void AddUserControls()
        {
            for (var i = 0; i < userControls.Count; i++) {
                userControls[i].Dock = DockStyle.Fill;
                panel.Controls.Add(userControls[i]);
            }
        }

        public void Display(int index)
        {
            if (index < userControls.Count) {
                userControls[index].BringToFront();
            }
        }
    }
}
