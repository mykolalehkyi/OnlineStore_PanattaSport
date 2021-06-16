//import swal from "../../node_modules/sweetalert/typings/sweetalert";
class ShoppingCartIndexPageController {
    constructor() {
        this.datatableId = "shoppingCartTable";
        $(document).ready(() => this.init());
    }
    init() {
        this.initDataTable();
        this.initButtons();
    }
    initButtons() {
        $("#btnConfirmCart").click(function () {
            shoppingCartIndexPageController.confirmCart();
        });
        $("#btnClearCart").click(function () {
            shoppingCartIndexPageController.clearCart();
        });
    }
    initDataTable() {
        this.datatable = $("#" + this.datatableId).DataTable({
            "ajax": {
                "url": "ShoppingCart/GetListShoppingCart",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "productId" },
                { "data": "productName" },
                { "data": "quantity" },
                { "data": "unitPrice" },
                { "data": "total" }
            ],
            "footerCallback": function (row, data, start, end, display) {
                let api = this.api();
                //Remove foramation
                let intVal = function (i) {
                    return typeof i === 'string' ?
                        Number.parseInt(i) * 1 :
                        typeof i === 'number' ?
                            i : 0;
                };
                let total = api
                    .column(4)
                    .data()
                    .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
                $(api.column(4).footer()).text(total);
            }
        });
    }
    confirmCart() {
        $.ajax({
            url: "ShoppingCart/ConfirmCart/",
            method: "POST",
            success: function (dataResponse) {
                if (dataResponse.success) {
                    alert(dataResponse.message);
                    shoppingCartIndexPageController.refreshDataTable();
                    shoppingCartSharedPartialController.setCounterCart(0);
                }
                else {
                    alert(dataResponse.message);
                    //swal("Are you sure you want to do this?", {
                    //    buttons: ["Oh noez!", "Aww yiss!"],
                    //});
                }
            }
        });
    }
    clearCart() {
        $.ajax({
            url: "ShoppingCart/ClearCart/",
            method: "POST",
            success: function (dataResponse) {
                if (dataResponse.success) {
                    alert(dataResponse.message);
                    shoppingCartIndexPageController.refreshDataTable();
                    shoppingCartSharedPartialController.setCounterCart(0);
                }
                else {
                    alert(dataResponse.message);
                }
            }
        });
    }
    refreshDataTable() {
        let datatable = $("#" + shoppingCartIndexPageController.datatableId).DataTable();
        datatable.ajax.reload();
    }
}
let shoppingCartIndexPageController = new ShoppingCartIndexPageController();
//# sourceMappingURL=shoppingCartIndex.js.map