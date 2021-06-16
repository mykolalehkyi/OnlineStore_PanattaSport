
class AdminProductIndexPageController {
    datatable;

    constructor() {
        $(document).ready(() => this.init());
    }

    init(): void {
        this.initDataTable();
    }

    initDataTable(): void {
        this.datatable = $("#productTable").DataTable({
            "ajax": {
                "url": "Products/GetList",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "productId" },
                { "data": "productName" },
                { "data": "width" },
                { "data": "length" },
                { "data": "height" },
                { "data": "weight" },
                { "data": "standardLoad" },
                { "data": "optionalLoad" },
                {
                    "data": "disabled",
                    "render": function (data, type, row) {
                        if (data == false) {
                            return `<button class="btn btn-danger" onclick="adminProductIndexPageController.deactivateProduct('Products/DeactivateProduct?id=${row.productId}')" >Deactivate</button>`;
                        }
                        else {
                            return `<button class="btn btn-success" onclick="adminProductIndexPageController.activateProduct('Products/ActivateProduct?id=${row.productId}')" >Activate</button>`;
                        }
                        return data;
                    }
                },
                {
                    "data": "productId",
                    "render": function (data) {
                        return `<nobr><a href="Products/Edit?id=${data}" class="btn btn-primary">✎</a>
                        <a href="Products/Details?id=${data}" class="btn btn-info">📝</a></nobr>`
                    }
                }
            ]
        });
    }

    populateDataTable(dataToTable) {
        this.datatable = $("#productTable").DataTable();
        this.datatable.clear().draw();
        this.datatable.rows.add(dataToTable.data); // Add new data
        this.datatable.columns.adjust().draw(); // Redraw the DataTable
    }

    deactivateProduct(url) {
        $.ajax({
            type: "PUT",
            url: url,
            success: function (data) {
                if (data.success) {
                    alert(data.message);
                    let datatable = $("#productTable").DataTable();
                    datatable.ajax.reload();
                }
                else {
                    alert(data.message);
                }
            }
        });
    }

    activateProduct(url) {
        $.ajax({
            type: "PUT",
            url: url,
            success: function (data) {
                if (data.success) {
                    alert(data.message);
                    let datatable = $("#productTable").DataTable();
                    datatable.ajax.reload();
                }
                else {
                    alert(data.message);
                }
            }
        });
    }

}

let adminProductIndexPageController = new AdminProductIndexPageController();
