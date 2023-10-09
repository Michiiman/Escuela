
using ApiEscuela.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiEscuela.Controllers;

public class LoginController : Controller
{
    [HttpPost("getTokenLogin")]
    public ActionResult GetTokenLogin([FromForm] string email, [FromForm] string password)
    {
        Clases.Log.LogWrite($"GetTokenLogin: email={email}, password={password}");
        Clases.Login log = new Clases.Login();
        return Ok(log.getTokenLogin(email, password));
    }

    [HttpPost("loginByToken")]
    public ActionResult LoginByToken([FromBody] RegisterDto data)
    {
        Clases.Log.LogWrite($"LoginByToken: loginToken={data.LoginToken}");
        Clases.Login log = new Clases.Login();
        string token = log.LoginByToken(data.LoginToken, data);

        switch (token)
        {
            case "-1": return BadRequest("Límite de tiempo excedido");
            case "-2": return BadRequest("Usuario o clave incorrectos");
            case "-3": return BadRequest("No se pudo hacer el login, revise los datos enviados");
            default: return Ok(token);
        }
    }


}
