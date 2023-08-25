var idReg;
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


