"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var sweetalert2_1 = require("sweetalert2");
var toastr = require("toastr");
var AdminProductIndexPageController = /** @class */ (function () {
    function AdminProductIndexPageController() {
        var _this = this;
        $(document).ready(function () { return _this.init(); });
    }
    AdminProductIndexPageController.prototype.init = function () {
        this.initDataTable();
    };
    AdminProductIndexPageController.prototype.initDataTable = function () {
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
                    "render": function (data) {
                        if (data == false) {
                            return "<button class=\"btn btn-danger\" onclick=\"adminProductIndexPageController.deactivateProduct('/Products/DeactivateProduct?id=" + data + "')\" >Deactivate</button>";
                        }
                        else {
                            return "<button class=\"btn btn-success onclick=\"adminProductIndexPageController.deactivateProduct('/Products/ActivateProduct?id=" + data + "')\" >Activate</button>";
                        }
                    }
                },
                {
                    "data": "productId",
                    "render": function (data) {
                        return "<a href=\"Products/Edit?id=" + data + "\" class=\"btn btn-info\">Edit</a>\n                        <a href=\"Products/Details?id=" + data + "\" class=\"btn btn-primary\">Details</a>";
                    }
                }
            ]
        });
    };
    AdminProductIndexPageController.prototype.populateDataTable = function (dataToTable) {
        this.datatable = $("#productTable").DataTable();
        this.datatable.clear().draw();
        this.datatable.rows.add(dataToTable.data); // Add new data
        this.datatable.columns.adjust().draw(); // Redraw the DataTable
    };
    AdminProductIndexPageController.prototype.deactivateProduct = function (url) {
        sweetalert2_1.default.fire({
            title: "Are you sure",
            text: "This item will not be displayed to user",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Deactivate"
        }).then(function (result) {
            if (result) {
                $.ajax({
                    type: "PUT",
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            this.datatable.ajax.reload();
                        }
                        else {
                            toastr.error(data.message);
                        }
                    }
                });
            }
        });
    };
    return AdminProductIndexPageController;
}());
var adminProductIndexPageController = new AdminProductIndexPageController();
//# sourceMappingURL=adminProductsIndex.js.map