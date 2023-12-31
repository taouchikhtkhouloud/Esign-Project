﻿namespace Esign.Client.Infrastructure.Routes
{
    public static class DocumentsEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString)
        {
            return $"api/documents?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}";
        }

        public static string GetById(int documentId)
        {
            return $"api/documents/{documentId}";
        }

        public static string GetFilesPaged(int folderid ,int pageNumber, int pageSize, string searchString)
        {
            return $"api/documents/{folderid}?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}";
        }

        public static string Save = "api/documents";
        public static string Delete = "api/documents";
        public static string GetByFolder = "/ByFolder";
        public static string Sign = "/Sign";

    }
}