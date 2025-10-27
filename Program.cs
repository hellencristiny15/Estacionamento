Console.Clear();

const decimal PrecoPrimeiraHora = 20;
const decimal PrecoHoraPequeno = 10;
const decimal PrecoHoraGrande = 20;
const decimal PrecoDiariaPequeno = 50;
const decimal PrecoDiariaGrande = 80;
const double AdicionalValet = 0.2;
const decimal PrecoLavaegemPequeno = 50;
const decimal PrecoLavaegemGrande = 100;

const int TempoDiaria = 5 * 60;
const int TempoTolerancia = 5;
const int MaxTempoPermanencia = 12 * 60;

int tempoPermanencia;
string tamanho;
bool valet, lavagem;

decimal ParcialEstacionamento = 0;
decimal ParcialValet = 0;
decimal ParcialLavagem = 0;
decimal Total = 0;

Console.WriteLine("Bem-vindo ao sistema de estacionamento!");

Console.Write("Tamanho do veículo (P/G): ");
tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (tamanho != "P" && tamanho != "G")
{
    Console.WriteLine("Tamanho Inválido!");
    return;
}

Console.Write("Tempo de Permanência (min)...:");
tempoPermanencia = Convert.ToInt32(Console.ReadLine());

if (tempoPermanencia <= 0 || tempoPermanencia > MaxTempoPermanencia)
{
    Console.WriteLine("Tempo de Permanência Inválido!");
    return;
}

Console.Write("Serviço de Valet (S/N)......: ");
valet = Console.ReadLine()!.Trim().Substring(0, 1) == "S";

Console.Write("Serviço de Lavagem (S/N)....: ");
lavagem = Console.ReadLine()!.Trim().Substring(0, 1) == "S";

if (tempoPermanencia >= TempoDiaria)
{
    if (tamanho == "P")
    {
        ParcialEstacionamento = PrecoDiariaPequeno;
    }
    else
    {
        ParcialEstacionamento = PrecoDiariaGrande;
    }

}
else
{
    int horasPermanencia = (int)(tempoPermanencia / 60);
    int minutosRestantes = tempoPermanencia % 60;

    if (minutosRestantes > TempoTolerancia)
    {
        horasPermanencia++;
    }

    ParcialEstacionamento = PrecoPrimeiraHora;
    int horasAdicionais = horasPermanencia - 1;

    if (horasAdicionais > 0)
    {
        if (tamanho == "P")
        {
            ParcialEstacionamento += horasAdicionais * PrecoHoraPequeno;
        }
        else
        {
            ParcialEstacionamento += horasAdicionais * PrecoHoraGrande;
        }
    }
}

if (valet)
{
    ParcialValet = ParcialEstacionamento * Convert.ToDecimal(AdicionalValet);
}

if (lavagem)
{
    if (tamanho == "P")
    {
        ParcialLavagem = PrecoLavaegemPequeno;
    }
    else
    {
        ParcialLavagem = PrecoLavaegemGrande;
    }
}

Total = ParcialEstacionamento + ParcialValet + ParcialLavagem;

Console.WriteLine($"\nEstacionamento..: {ParcialEstacionamento,14:C}");
Console.WriteLine($"Serviço Valet...: {ParcialValet,14:C}");
Console.WriteLine($"Serviço Lavagem.: {ParcialLavagem,14:C}");
Console.WriteLine($"------------------------------");
Console.WriteLine($"Total...........: {Total,14:C}");