using System.Data;
using System.Data.SqlClient;
using ApiEscuela.Dtos;

namespace ApiEscuela.Clases;

public class Login
{
    public string getTokenLogin(string email, string password)
    {
        Encriptacion encrip = new Encriptacion();
        string fecha = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        string tokenLogin = encrip.AES256_Encriptar(encrip.AES256_LOGIN_Key, fecha + '#' + email + '#' + encrip.GetSHA256(password));
        return tokenLogin;
    }

/*     public string LoginByToken(string loginToken)
    {
        try
        {
            Encriptacion encrip = new Encriptacion();
            string tokenUsuario = "";

            string tokenDescoficado = encrip.AES256_Desencriptar(encrip.AES256_LOGIN_Key, loginToken);
            string fecha = tokenDescoficado.Split('#')[0];
            string email = tokenDescoficado.Split('#')[1];
            string password = tokenDescoficado.Split('#')[2];

            // Validar fecha
            DateTime fechaLogin = DateTime.ParseExact(fecha, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            if (DateTime.UtcNow.Subtract(fechaLogin).TotalSeconds >= 30)
            {
                return "-1";    // -1 = Límite de tiempo excedido
            }

            // Validar login
            string SQL = $"SELECT * FROM dbo.USuarios WHERE email='{email}' AND password=0x{password}";

            DataTable dt = AccesoDatos.GetTmpDataTable(SQL);
            if (dt.Rows.Count > 0)
            {
                tokenUsuario = dt.Rows[0]["email"].ToString() + "#" + DateTime.UtcNow.AddHours(18).ToString("yyyyMMddHHmmss");        // Email # FechaCaducidad -> Encriptar con AES
                tokenUsuario = encrip.AES256_Encriptar(encrip.AES256_USER_Key, tokenUsuario);
                return tokenUsuario;
            }
            else
            {
                return "-2";    // -2 = Usuario o clave incorrectas
            }
        }
        catch (Exception)
        {
            return "-3";        // -3 = Error
        }
    } */

    public string LoginByToken(string loginToken, RegisterDto registerDto)
    {
        try
        {
            Encriptacion encrip = new Encriptacion();
            string tokenUsuario = "";
            string claveCod= encrip.GetSHA256(registerDto.Password);
            string tokenDescoficado = encrip.AES256_Desencriptar(encrip.AES256_LOGIN_Key, loginToken);
            string fecha = tokenDescoficado.Split('#')[0];
            string email = tokenDescoficado.Split('#')[1];
            string password = tokenDescoficado.Split('#')[2];
            Console.WriteLine(email);
            Console.WriteLine(password);
            Console.WriteLine(claveCod);
            Console.WriteLine(registerDto.Email);
            Console.WriteLine(registerDto.Password);
            // Validar fecha
            DateTime fechaLogin = DateTime.ParseExact(fecha, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            if (DateTime.UtcNow.Subtract(fechaLogin).TotalSeconds >= 60)
            {
                return "-1";    // -1 = Límite de tiempo excedido
            }

            // Validar login (simulado sin conexión a la base de datos)
            if (email == registerDto.Email && password == claveCod)
            {
                // Usuario autenticado, genera un nuevo token
                tokenUsuario = email + "#" + DateTime.UtcNow.AddHours(18).ToString("yyyyMMddHHmmss");
                tokenUsuario = encrip.AES256_Encriptar(encrip.AES256_USER_Key, tokenUsuario);
                return tokenUsuario;
            }
            else
            {
                return "-2";    // -2 = Usuario o contraseña incorrectos
            }
        }
        catch (Exception)
        {
            return "-3";        // -3 = Error
        }
    }

}
