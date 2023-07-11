using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esign.Client.Pages.Misc
{
    public partial class SignDocument
    {
       
            private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            private const int CodeLength = 8;

        [Parameter] public int documentId { get; set; }

        public string GenerateCode()
            {
                var random = new Random();
                var codeBuilder = new StringBuilder();

                for (int i = 0; i < CodeLength; i++)
                {
                    int index = random.Next(Characters.Length);
                    char character = Characters[index];
                    codeBuilder.Append(character);
                }

                return codeBuilder.ToString();
            }
    }

       
}


