using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;

namespace listy
{
    public class Film
    {
        static int licznikInstancji = 0;
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Kategoria { get; set; }
        public int RokProdukcji { get; set; }
        public bool TylkodlaDoroslych { get; set; }
        public Button Button { private get; set; }

        public Film(string tytul, string kategoria, int rokProdukcji, bool tylkodlaDoroslych)
        {
            licznikInstancji++;
            Id = licznikInstancji;
            Tytul = tytul;
            Kategoria = kategoria;
            RokProdukcji = rokProdukcji;
            TylkodlaDoroslych = tylkodlaDoroslych;
            Button = new Button();
            Button.Name = ("b" + Id.ToString());
            Button.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(MainWindow.instance.usun));
        }
    }
}
