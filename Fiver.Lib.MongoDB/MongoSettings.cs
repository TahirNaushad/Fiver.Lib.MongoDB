using System;

namespace Fiver.Lib.MongoDB
{
    public sealed class MongoSettings
    {
        public MongoSettings(string connectionString, 
                             string databaseName,
                             string collectionName)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");

            if (string.IsNullOrEmpty(databaseName))
                throw new ArgumentNullException("databaseName");

            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentNullException("collectionName");

            this.ConnectionString = connectionString;
            this.DatabaseName = databaseName;
            this.CollectionName = collectionName;
        }

        public string ConnectionString { get; }
        public string DatabaseName { get; }
        public string CollectionName { get; }
    }
}
