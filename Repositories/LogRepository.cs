﻿using D3___Avaliação.Interfaces;
using D3___Avaliação.Models;
using System.Text;

namespace D3___Avaliação.Repositories
{
    internal class LogRepository : ILog    
    {
        private const string path = "database/userLog.txt";
        private readonly FileStream _fileStream;

        public LogRepository(FileStream fileStream)
        {
            CreateFolderFile(path);
            this._fileStream = fileStream;
        }

        public static void CreateFolderFile(string path)//CopyPast do gitHub; Apenas para certificar que a pasta existirá;
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static string PrepareLineLogin(User user)
        {
            return $"O usuário {user.Name} - id: {user.IdUser} acessou o sistema as {DateTimeOffset.Now}.\n";
        }
        private static string PrepareLineLogout(User user)
        {
            return $"O usuário {user.Name} - id: {user.IdUser} deslogou do sistema as {DateTimeOffset.Now}.\n";
        }

        public void RegisterAccess(User user)
        {
            string line = PrepareLineLogin(user);
            byte[] info = new UTF8Encoding(true).GetBytes(line);

            _fileStream.Write(info);
        }
        public void RegisterLogout(User user)
        {
            string line = PrepareLineLogout(user);
            byte[] info = new UTF8Encoding(true).GetBytes(line);

            _fileStream.Write(info);
        }
    }
}

