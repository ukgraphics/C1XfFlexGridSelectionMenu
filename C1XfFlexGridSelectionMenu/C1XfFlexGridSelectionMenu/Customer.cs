using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace C1XfFlexGridSelectionMenu
{
    public class Customer
    {
        int _id, _countryID;
        string _first, _last;
        bool _active;
        double _weight;
        DateTime _hired;
        static Random _rnd = new Random();
        static string[] _firstNames = "Gil|Oprah|Xavier|Herb|Charlie|Larry|Steve".Split('|');
        static string[] _lastNames = "Orsted|Frommer|Jammers|Krause|Neiman".Split('|');
        static string[] _countries = "ブラジル|コンゴ|エジプト|アメリカ|日本|タイ".Split('|');

        public Customer()
            : this(_rnd.Next(10000))
        {
        }
        public Customer(int id)
        {
            ID = id;
            First = GetString(_firstNames);
            Last = GetString(_lastNames);
            CountryID = _rnd.Next() % _countries.Length;
            Active = _rnd.NextDouble() >= .5;
            Hired = DateTime.Today.AddDays(-_rnd.Next(1, 365));
            Weight = 50 + _rnd.NextDouble() * 50;
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return string.Format("{0} {1}", First, Last); }
        }
        public string Country
        {
            get { return _countries[_countryID]; }
        }
        public int CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public string First
        {
            get { return _first; }
            set { _first = value; }
        }
        public string Last
        {
            get { return _last; }
            set { _last = value; }
        }
        public DateTime Hired
        {
            get { return _hired; }
            set { _hired = value; }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        static string GetString(string[] arr)
        {
            return arr[_rnd.Next(arr.Length)];
        }
        static string GetName()
        {
            return string.Format("{0} {1}", GetString(_firstNames), GetString(_lastNames));
        }
        // 静的な一覧を指定します
        public static ObservableCollection<Customer> GetCustomerList(int count)
        {
            var list = new ObservableCollection<Customer>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Customer(i));
            }
            return list;
        }
        // 静的な値のメンバーを指定します
        public static string[] GetCountries() { return _countries; }
        public static string[] GetFirstNames() { return _firstNames; }
        public static string[] GetLastNames() { return _lastNames; }
    }
}