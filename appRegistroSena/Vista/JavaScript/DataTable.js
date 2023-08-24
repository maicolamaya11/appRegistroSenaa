var idp;
var table;
var listaPersonal;

$(document).ready(function () {
    table = $('#DataTableRegistros').DataTable({
        data: jsonData,
        columns: [
            { data: 'Codigo' },
            { data: 'horaIng' },
            { data: 'horaSalida' },
            { data: 'documentoPerson' },
            { data: 'nombrePort' },
            { data: 'documentoUsua' },
            {
                "data": null,
                "defaultContent": "<div class='text-center'><div class='btn-group'><button class='btn btn-primary btn-sm btnEditar'><i class='material-icons'>edit</i></button><button class='btn btn-danger btn-sm btnBorrar'><i class='material-icons'>delete</i></button></div></div>",
            }

        ]
    })
})

$('#DataTableRegistros').on('click', '.btnEditar', function (e) {

    e.preventDefault();
    var rowData = $('#DataTableRegistros').DataTable().row($(this).closest('tr')).data();
    cod = rowData.Codigo
    $.ajax({
        url: "ListaRegistrosRealizados.aspx/mtdCargarDatos",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ Codigo: cod }),
        success: function (Data) {

            var datosProducto = Data.d;
            $('.txt-codigo-registro').val(datosProducto[0]["Codigo"]);
            $('.txt-horaIngreso-registro').val(datosProducto[0]["horaIng"]);
            $('.txt-horaSalida-registro').val(datosProducto[0]["horaSalida"]);
            $('.txt-documentoP-registro').val(datosProducto[0]["documentoPerson"]);
            $('.txt-nombrePo-registro').val(datosProducto[0]["nombrePort"]);
            $('.txt-documentoU-registro').val(datosProducto[0]["documentoUsua"]);

            $('#editarModal').modal('show');
        },
        error: function (error) {
            console.log(error);
        }
    });
})

$('#btnActualizar').on('click', function (e) {
    e.preventDefault();

    var IdPersonal = idp;
    var Documento = $('.txt-documento-personal').val();
    var Nombre = $('.txt-nombre-personal').val();
    var Apellido = $('.txt-apellido-personal').val();
    var Ciudad = $('.txt-ciudad-personal').val();
    var Telefono = $('.txt-telefono-personal').val();

    var DatosActualizados = {
        IdPersonal: IdPersonal,
        Documento: Documento,
        Nombre: Nombre,
        Apellido: Apellido,
        Ciudad: Ciudad,
        Telefono: Telefono
    };

    // Realiza la petición Ajax
    $.ajax({
        url: "DataTableVista.aspx/mtdActualizarPersonal",
        type: "POST",
        data: JSON.stringify({ data: DatosActualizados }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            recargarTabla();
            swal("¡Éxito!", "Los datos se actualizaron correctamente.", "success");
            $('#editarModal').modal('hide'); // Cierra la ventana modal
        },
        error: function (error) {
            console.log(error);
        }

    });
});

function recargarTabla() {
    $.ajax({
        url: "DataTableVista.aspx/mtdListar",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            listaPersonal = response.d;
            // Limpiar los datos actuales de la tabla
            table.clear();
            // Agregar los nuevos datos a la tabla
            table.rows.add(listaPersonal);
            // Dibujar la tabla con los datos actualizados
            table.draw();

            console.log(listaPersonal);
        },
        error: function (error) {
            console.log(error);
        }
    });

}

$('#DataTableExplicacion').on('click', '.btnBorrar', function (e) {
    e.preventDefault();

    var rowData = $('#DataTableExplicacion').DataTable().row($(this).closest('tr')).data();
    var idp = rowData.IdPersonal;

    swal({
        title: "¿Estás seguro?",
        text: "Esta acción no se puede deshacer",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar"
    }, function (isConfirmed) {
        if (isConfirmed) {
            // Código para eliminar el registro

            var data = {
                formData: {
                    IdPersonal: idp
                }
            };

            // Realiza la petición Ajax para eliminar el registro
            $.ajax({
                url: "DataTableVista.aspx/mtdEliminar",
                type: "POST",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (Data) {
                    if (Data) {

                        swal("¡Éxito!", "Los datos se eliminaron correctamente.", "success");
                    }
                    recargarTabla()
                },
                error: function (error) {
                    console.log(error);
                }
            });

        }
    });
});