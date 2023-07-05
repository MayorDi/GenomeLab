using GenomeAnalyzer;

namespace GenomeLab;

public class Project
{
    public string Name { get; set; }
    public Genome Genome { get; set; }

    public Project()
    {
        Name = "";
        Genome = new Genome();
    }

    public Project(string name, Genome genome)
    {
        Name = name;
        Genome = genome;
    }
}