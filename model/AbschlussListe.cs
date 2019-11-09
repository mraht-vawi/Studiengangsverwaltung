﻿using System;
using System.Collections.ObjectModel;

namespace Universitätsverwaltung.model
{
    [Serializable]
    public class AbschlussListe : ObservableCollection<Abschluss>
    {
        private static AbschlussListe instance;

        public static AbschlussListe Instance
        {
            get { return instance ?? (instance = new AbschlussListe()); }
        }

        public static void SetInstance(AbschlussListe abschlussListe)
        {
            instance = abschlussListe;
        }

        public AbschlussListe() { }
    }
}
