var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/employee/getall',
            error: function (xhr, error, thrown) {
                console.log('DataTables error: ' + error);
            }
},
        "columns": [
            { data: 'firstName', "width": "25%" },
            { data: 'lastName', "width": "20%" },
            { data: 'dateOfHire', "width": "15%" },
            { data: 'departament.name', "width": "15%" },
            { data: 'salary', "width": "15%" },
            { data: 'dateOfBirth', "width": "15%" },
            { data: 'email', "width": "15%" },
            { data: 'streetAdress', "width": "25%" },
            { data: 'phoneNumber', "width": "15%" },
            { data: 'city', "width": "15%" },
            { data: 'state', "width": "15%" },
            { data: 'postalCode', "width": "15%" },
            { data: 'country', "width": "15%" },

            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/employee/upsert?id=${data}" class="btn btn-dark mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                     <a onClick=Delete('/admin/employee/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}