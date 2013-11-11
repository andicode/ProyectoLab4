var xmlHttpRequest;

function BuscarEmpleado(param)
{
    with (document)
    {
        //Borramos el Contenido del TextArea donde mostraremos los resultados
        getElementById("Listado").value = "";

        //Creamos un objeto XMLHttpRequest
        xmlHttpRequest = (window.XMLHttpRequest) ?
            new XMLHttpRequest() : new ActiveXObject("Msxml2.XMLHTTP");
        
        //Si el navegador no soporta Ajax, cortamos la ejecución de éste código
        if (xmlHttpRequest == null)
            return;

        //Iniciamos el objeto XMLHttpRequest, pasándole la URL que queremos procesar y en este caso la variable con la cual iremos a la Base de Datos
        xmlHttpRequest.open("GET", "ObtenerEmpleados.aspx?param="+param, true);

        //Seteamos la función que ejecutará el Callback
        xmlHttpRequest.onreadystatechange = CambioDeEstado;

        //Enviamos el request Ajax al servidor con la información del GET        
        xmlHttpRequest.send(null);
    }
}

function CambioDeEstado()
{
    with (document)
    {
        //Esperamos que el ReadyState sea 4, esto es, cuando el Response del Server fue completado y entonces actualizamos el valor del TextArea con la info devuelta por el procesamiento de la URL.
        if (xmlHttpRequest.readyState == 4)
            getElementById("Listado").value = xmlHttpRequest.responseText;
    }
}