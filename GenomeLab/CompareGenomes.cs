using GenomeAnalyzer;

namespace GenomeLab;

public class CompareGenomes
{ 
    public static Project Project1 { get; set; }
    public static Project Project2 { get; set; }

    public static TypeCell ToCellType(int idx)
    {
        switch (idx)
        {
            case 0:
                return TypeCell.Phagocyte;
            case 1:
                return TypeCell.Flagellocyte;
            case 2:
                return TypeCell.Photocyte;
            case 3:
                return TypeCell.Devorocyte;
            case 4:
                return TypeCell.Lipocyte;
            case 5:
                return TypeCell.Keratinocyte;
            case 6:
                return TypeCell.Buyocyte;
            case 7:
                return TypeCell.Glueocute;
            case 8:
                return TypeCell.Virocyte;
            case 9:
                return TypeCell.Stereocyte;
            case 10:
                return TypeCell.Senseocyte;
            case 11:
                return TypeCell.Myocyte;
            case 12:
                return TypeCell.Neurocyte;
            case 13:
                return TypeCell.Secrocyte;
            case 14:
                return TypeCell.Stemocyte;
            case 15:
                return TypeCell.Gamete;
            case 16:
                return TypeCell.Ciliocyte;


        }

        return TypeCell.Phagocyte;
    }

    public enum TypeCell
    {
        Phagocyte,
        Flagellocyte,
        Photocyte,
        Devorocyte,
        Lipocyte,
        Keratinocyte,
        Buyocyte,
        Glueocute,
        Virocyte,
        Stereocyte,
        Senseocyte,
        Myocyte,
        Neurocyte,
        Secrocyte,
        Stemocyte,
        Gamete,
        Ciliocyte,
    }
}