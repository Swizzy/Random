namespace SwizzContact {
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlServerCe;
    using SwizzContact.Properties;

    public class Sqlmanager {
        private readonly SqlCeConnection _connection;

        public Sqlmanager(string path) {
            _connection = new SqlCeConnection(string.Format(Resources.SQLConnect, path));
        }

        public IEnumerable<Dbentry> GetData() {
            IList<Dbentry> ret = new List<Dbentry>();
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            var cmd = new SqlCeCommand("SELECT Contacts.* FROM Contacts", _connection);
            var sdr = cmd.ExecuteReader();
            while(sdr.Read()) {
                var tmp = new Dbentry { Id = sdr["ID"].ToString(), Name = sdr["Name"].ToString(), Email = sdr["Email"].ToString(), Adress = sdr["Adress"].ToString(), Zipcode = sdr["ZipCode"].ToString(), Country = sdr["Country"].ToString(), Area = sdr["Area"].ToString(), Office = sdr["Office"].ToString(), Mobile = sdr["Mobile"].ToString(), Home = sdr["Home"].ToString(), Company = sdr["Company"].ToString(), Other = sdr["Other"].ToString() };
                ret.Add(tmp);
            }
            _connection.Close();
            GC.Collect();
            return ret;
        }

        public IEnumerable<Dbentry> GetLast() {
            IList<Dbentry> ret = new List<Dbentry>();
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            var cmd = new SqlCeCommand("SELECT TOP 1 Contacts.* FROM Contacts ORDER BY ID DESC", _connection);
            var sdr = cmd.ExecuteReader();
            while(sdr.Read()) {
                var tmp = new Dbentry { Id = sdr["ID"].ToString(), Name = sdr["Name"].ToString(), Email = sdr["Email"].ToString(), Adress = sdr["Adress"].ToString(), Zipcode = sdr["ZipCode"].ToString(), Country = sdr["Country"].ToString(), Area = sdr["Area"].ToString(), Office = sdr["Office"].ToString(), Mobile = sdr["Mobile"].ToString(), Home = sdr["Home"].ToString(), Company = sdr["Company"].ToString(), Other = sdr["Other"].ToString() };
                ret.Add(tmp);
            }
            _connection.Close();
            GC.Collect();
            return ret;
        }

        public void Deleteentry(string id) {
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            var cmd = new SqlCeCommand(string.Format("DELETE FROM Contacts WHERE Id='{0}'", id), _connection);
            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Dbentry> GetFilterd(string name = "", string email = "", string country = "", string adress = "", string zip = "", string area = "", string company = "") {
            IList<Dbentry> ret = new List<Dbentry>();
            if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(adress) && string.IsNullOrEmpty(zip) && string.IsNullOrEmpty(area) && string.IsNullOrEmpty(company))
                return GetData();
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            var cmds = "SELECT Contacts.* FROM Contacts WHERE ";
            if(!string.IsNullOrEmpty(name))
                cmds += string.Format("Name LIKE '%{0}%',", name);
            if(!string.IsNullOrEmpty(email))
                cmds += string.Format("Email LIKE '%{0}%',", email);
            if(!string.IsNullOrEmpty(adress))
                cmds += string.Format("Adress LIKE '%{0}%',", adress);
            if(!string.IsNullOrEmpty(zip))
                cmds += string.Format("ZipCode LIKE '%{0}%',", zip);
            if(!string.IsNullOrEmpty(country))
                cmds += string.Format("Country LIKE '%{0}%',", country);
            if(!string.IsNullOrEmpty(area))
                cmds += string.Format("Area LIKE '%{0}%',", area);
            if(!string.IsNullOrEmpty(company))
                cmds += string.Format("Company LIKE '%{0}%',", company);
            var cmd = new SqlCeCommand(cmds.Substring(0, cmds.Length - 1), _connection);
            var sdr = cmd.ExecuteReader();
            while(sdr.Read()) {
                var tmp = new Dbentry { Id = sdr["ID"].ToString(), Name = sdr["Name"].ToString(), Email = sdr["Email"].ToString(), Adress = sdr["Adress"].ToString(), Zipcode = sdr["ZipCode"].ToString(), Country = sdr["Country"].ToString(), Area = sdr["Area"].ToString(), Office = sdr["Office"].ToString(), Mobile = sdr["Mobile"].ToString(), Home = sdr["Home"].ToString(), Company = sdr["Company"].ToString(), Other = sdr["Other"].ToString() };
                ret.Add(tmp);
            }
            _connection.Close();
            GC.Collect();
            return ret;
        }

        public void AddContact(Dbentry data) {
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            var cmd = new SqlCeCommand(string.Format(Resources.SQLInsert, data.Name, data.Email, data.Adress, data.Zipcode, data.Country, data.Area, data.Office, data.Mobile, data.Home, data.Company, data.Other), _connection);
            cmd.ExecuteNonQuery();
            GC.Collect();
        }

        public void UpdContact(Dbentry data) {
            if(_connection.State == ConnectionState.Closed)
                _connection.Open();
            var cmd = new SqlCeCommand(string.Format(Resources.SQLUpdate, data.Name, data.Email, data.Adress, data.Zipcode, data.Country, data.Area, data.Office, data.Mobile, data.Home, data.Company, data.Other, data.Id), _connection);
            cmd.ExecuteNonQuery();
            GC.Collect();
        }

        #region Nested type: Dbentry

        public struct Dbentry {
            public string Adress;
            public string Area;
            public string Company;
            public string Country;
            public string Email;
            public string Home;
            public string Id;
            public string Mobile;
            public string Name;
            public string Office;
            public string Other;
            public string Zipcode;
        }

        #endregion
    }
}