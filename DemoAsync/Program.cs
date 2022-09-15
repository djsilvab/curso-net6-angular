using DemoAsync;
using System.Diagnostics;

Stopwatch swatch = new Stopwatch();
swatch.Start();

Console.WriteLine("\nBienvenido a la calculadora de Hipoteca Síncrona");

var aniosVidaLaboral = CalculadoraHipotecaSync.ObtenerAniosVidaLaboral();
Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboral}");

var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoIndefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo neto obtenido: {sueldoNeto}$");

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"\nGastos Mensuales obtenidos: {gastosMensuales}$");

var hipotecaConcebida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(
    aniosVidaLaboral, esTipoContratoIndefinido, sueldoNeto, gastosMensuales, cantidadSolicitado: 50000, aniosPagar: 30);

var resultado = hipotecaConcebida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnálisis Finalizado. Su solicitud de hipoteca ha sido: {resultado}");

swatch.Stop();

Console.WriteLine($"\nLa operación ha durado: {swatch.Elapsed}");

//restart
swatch.Restart();
Console.WriteLine(new String('*', 10));
Task<int> aniosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAniosVidaLaboral();
Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoIndefinido();
Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();
Task<int> gastosMensualesTask = CalculadoraHipotecaAsync.ObtenerGastosMensuales();

var lstTasks = new List<Task>()
{
    aniosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask
};

while (lstTasks.Any())
{
    Task taskFin = await Task.WhenAny(lstTasks);
    if(taskFin == aniosVidaLaboralTask)
    {
        Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboralTask.Result}");
    }
    else if(taskFin == esTipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");
    }else if(taskFin == sueldoNetoTask)
    {
        Console.WriteLine($"\nSueldo neto obtenido: {sueldoNetoTask.Result}$");
    }else if(taskFin == gastosMensualesTask)
    {
        Console.WriteLine($"\nGastos Mensuales obtenidos: {gastosMensualesTask.Result}$");
    }

    lstTasks.Remove(taskFin);
   
}

var hipotecaConcebidaAsync = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(
   aniosVidaLaboralTask.Result, esTipoContratoIndefinidoTask.Result, sueldoNetoTask.Result,
   gastosMensualesTask.Result, cantidadSolicitado: 50000, aniosPagar: 30);

var resultadoAsync = hipotecaConcebidaAsync ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnálisis Finalizado. Su solicitud de hipoteca async ha sido: {resultadoAsync}");

swatch.Stop();

Console.WriteLine($"\nLa operación async ha durado: {swatch.Elapsed}");

Console.ReadLine();