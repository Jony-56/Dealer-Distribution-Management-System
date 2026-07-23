using DDMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDMS.Domian.Entities
{
    public class Note :AuditableEntity
    {
        private Note()
        {
        }

        private Note(
            DateTime noteDate,
            string title,
            string content)
        {
            NoteDate = noteDate;
            Title = title;
            Content = content;
        }

        public DateTime NoteDate { get; private set; }

        public string Title { get; private set; } = string.Empty;

        public string Content { get; private set; } = string.Empty;

        public static Note Create(
            DateTime noteDate,
            string title,
            string content)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required.");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content is required.");

            return new Note(noteDate, title.Trim(), content.Trim());
        }
    }
}
