var idPer;
var table;
var listaPersonal;

$(document).ready(function () {
    table = $('#DataTableRegistros').DataTable({
        data: jsonData,
        columns: [
            { data: 'nombres' },
            { data: 'apellidos' },
            { data: 'documento' },
            { data: 'programa' },           
            { data: 'rol' },           
            {
                "data": null,
                "defaultContent": "<div class='text-center'><div class='btn-group'><button class='btn btn-primary btn-sm btnEditar'><i class='material-icons'>edit</i></button><button class='btn btn-danger btn-sm btnBorrar'><i class='material-icons'>delete</i></button></div></div>",
            }

        ]


    })

})
$// Escuchar el evento clic en elementos con la clase '.btnEditar' dentro del elemento con el ID '#DataTableRegistros'
$('#DataTableRegistros').on('click', '.btnEditar', function (e) {
    e.preventDefault(); // Prevenir el comportamiento predeterminado del enlace

    // Obtener los datos de la fila correspondiente al botón clicado utilizando DataTables
    var rowData = $('#DataTableRegistros').DataTable().row($(this).closest('tr')).data();
    var idPer = rowData.idPersonal; // Obtener el ID del personal

    // Realizar una solicitud AJAX para cargar datos utilizando el ID obtenido
    $.ajax({
        url: "ListarAprendices.aspx/mtdCargarDatos",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ idPersonal: idPer }),
        success: function (Data) {
            var datosProducto = Data.d; // Obtener los datos del servidor

            // Llenar los campos en el modal con los datos recibidos
            $('.txt-nombres-personal').val(datosProducto[0]["nombres"]);
            $('.txt-apellidos-personal').val(datosProducto[0]["apellidos"]);
            $('.txt-documento-personal').val(datosProducto[0]["documento"]);
            $('.txt-programa-personal').val(datosProducto[0]["programa"]);
            $('.txt-rol-personal').val(datosProducto[0]["rol"]);

            $('#editarModal').modal('show'); // Mostrar el modal de edición
        },
        error: function (error) {
            console.log(error); // Manejar errores en la consola
        }
    });
});




