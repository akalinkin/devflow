using System;

namespace GitLabCli.Dal.Projects.Boards 
{
    public class BoardList 
    {
        public uint Id { get; set; }
        public Label Label { get; set; }
        public ushort Position { get; set; }
    }

    public class Label 
    {
        public uint Id { get; set; }
        public String Name { get; set; }
        public String Color { get; set; }
        public String Description { get; set; }
    }
}
