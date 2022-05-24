namespace _220519_waveGoAlgoritm
{
    class Vertex
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Vertex(string name,int level=default)
        {
            Name = name;
            Level = level;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
