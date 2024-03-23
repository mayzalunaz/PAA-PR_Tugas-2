using Npgsql;
using System;
using System.Collections.Generic;

namespace Manajemen_Kelas_PR.Models
{
    public class SiswaContext
    {
        private string __constr;
        private string __ErrorMsg;

        public SiswaContext(string pConstr)
        {
            __constr = pConstr;
        }

        public List<Siswa> ListPerson()
        {
            List<Siswa> list1 = new List<Siswa>();
            string query = @"SELECT id_siswa, nama, alamat, kelas FROM school.kelas";
            using (var db = new NpgsqlConnection(__constr))
            {
                try
                {
                    db.Open();
                    using (var cmd = new NpgsqlCommand(query, db))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list1.Add(new Siswa()
                            {
                                id_siswa = int.Parse(reader["id_siswa"].ToString()),
                                nama = reader["nama"].ToString(),
                                alamat = reader["alamat"].ToString(),
                                kelas = reader["kelas"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }
            return list1;
        }

        public Siswa GetSiswaByID(int id_siswa)
        {
            Siswa siswa = null;
            string query = @"SELECT id_siswa, nama, alamat, kelas FROM school.kelas WHERE id_siswa = @id_siswa";
            using (var db = new NpgsqlConnection(__constr))
            {
                try
                {
                    db.Open();
                    using (var cmd = new NpgsqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@id_siswa", id_siswa);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                siswa = new Siswa()
                                {
                                    id_siswa = int.Parse(reader["id_siswa"].ToString()),
                                    nama = reader["nama"].ToString(),
                                    alamat = reader["alamat"].ToString(),
                                    kelas = reader["kelas"].ToString(),
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }
            return siswa;
        }

        public void AddSiswa(Siswa siswa)
        {
            string query = @"INSERT INTO school.kelas (nama, alamat, kelas) VALUES (@nama, @alamat, @kelas)";
            using (var db = new NpgsqlConnection(__constr))
            {
                try
                {
                    db.Open();
                    using (var cmd = new NpgsqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@nama", siswa.nama);
                        cmd.Parameters.AddWithValue("@alamat", siswa.alamat);
                        cmd.Parameters.AddWithValue("@kelas", siswa.kelas);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }
        }

        public void UpdateSiswa(Siswa siswa)
        {
            string query = @"UPDATE school.kelas SET nama = @nama, alamat = @alamat, kelas = @kelas WHERE id_siswa = @id_siswa";
            using (var db = new NpgsqlConnection(__constr))
            {
                try
                {
                    db.Open();
                    using (var cmd = new NpgsqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@nama", siswa.nama);
                        cmd.Parameters.AddWithValue("@alamat", siswa.alamat);
                        cmd.Parameters.AddWithValue("@kelas", siswa.kelas);
                        cmd.Parameters.AddWithValue("@id_siswa", siswa.id_siswa);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }
        }

        public void DeleteSiswa(int id_siswa)
        {
            string query = @"DELETE FROM school.kelas WHERE id_siswa = @id_siswa";
            using (var db = new NpgsqlConnection(__constr))
            {
                try
                {
                    db.Open();
                    using (var cmd = new NpgsqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@id_siswa", id_siswa);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    __ErrorMsg = ex.Message;
                }
            }
        }
    }
}
