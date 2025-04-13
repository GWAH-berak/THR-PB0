using System;
 
class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok; 
    }

    // Getter dan Setter
    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        throw new NotImplementedException("Metode ini harus diimplementasikan oleh kelas turunan");
    }
}

class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        double bonusTetap = 500000;
        return GajiPokok + bonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        double potonganKontrak = 200000;
        return GajiPokok - potonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok) : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GajiPokok; // Tidak ada bonus atau potongan
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sistem Manajemen Karyawan");
        Console.Write("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
        string jenisKaryawan = Console.ReadLine().Trim().ToLower();

        Console.Write("Masukkan nama karyawan: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID karyawan: ");
        string idKaryawan = Console.ReadLine();

        Console.Write("Masukkan gaji pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan = null;

        switch (jenisKaryawan)
        {
            case "tetap":
                karyawan = new KaryawanTetap(nama, idKaryawan, gajiPokok);
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak(nama, idKaryawan, gajiPokok);
                break;
            case "magang":
                karyawan = new KaryawanMagang(nama, idKaryawan, gajiPokok);
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
        }

        double gajiAkhir = karyawan.HitungGaji();
        Console.WriteLine($"Gaji akhir karyawan {karyawan.Nama} (ID: {karyawan.ID}): {gajiAkhir}");
    }
}