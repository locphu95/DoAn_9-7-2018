$(document).ready(function () {
    loadcb()
    loaddv()
    loadq()
    loadlgv()
});
function convertDatetime(dt) {
    res = dt.substring(8, 10) + "-" + dt.substring(5, 7) + "-" + dt.substring(0, 4);
    return res;
}
class Cbnv{
            constructor(maCBNV,tenCBNV){
                this.maCBNV=maCBNV;
                this.tenCBNV=tenCBNV;
            }
        };
function loadcb(){
    $.ajax({
        type: "GET",
        url: "/api/Cbnv",
        success: function(data){
            console.log(data);
            getData(data);

        }
    })
}
function loaddv(){
    $.ajax({
        type: "GET",
        url: "/api/Donvi",
        success: function(data){
            for(i=0;i<data.length;i++){
                 console.log(data[i]);
                 $("#madv").append(
                     "<option value ="+data[i]+">"+data[i].maDonVi+"<option>"
                 );
            }

        }
    })
}
function loadq(){
    $.ajax({
        type: "GET",
        url: "/api/Quyen",
        success: function(data){
            for(i=0;i<data.length;i++){
                 console.log(data[i]);
                 $("#maq").append(
                     "<option value ="+data[i]+">"+data[i].maQuyen+"<option>"
                 );
            }

        }
    })
}
function loadlgv(){
    $.ajax({
        type: "GET",
        url: "/api/Loaigv",
        success: function(data){
            for(i=0;i<data.length;i++){
                 console.log(data[i]);
                 $("#malgv").append(
                     "<option value ="+data[i]+">"+data[i].maLoaiGiangVien+"<option>"
                 );
            }

        }
    })
}
function getData(data) {
    $("#tbody").html("");
    data.forEach(item => {
        $("#tbody").append(loadcbnv(item));
    });

}
function loadcbnv(item) {
    detailsHtml ='<tr>';
    detailsHtml += '<td>'+item.maCBNV+'</td>'+
    '<td>'+item.hoCBNV +" "+ item.tenCBNV+'</td>'+
    '<td>'+item.dienThoai +'</td>'+
    '<td>'+item.hocVi +'</td>'+
    '<td>'+convertDatetime(item.ntns) +'</td>'+
    '<td>'+item.email +'</td>'+
    '<td>'
    +'<button type="button" class=" btn btn-info fa fa-edit showcn" onclick="suaCbnv(\'' + item.maCBNV + '\')"><span class="tooltiptext">Sửa</span></button>|<button type="button" class="btn btn-info fa fa-file-text-o showcn" onclick="chitietCbnv(\'' + item.maCBNV + '\')"><span class="tooltiptext">Chi tiết</span></button>|<button type="button" class="btn btn-info fa fa-trash-o showcn" onclick="suaCbnv(\'' + item.maCBNV + '\')"><span class="tooltiptext">Xóa </span></button> '
    detailsHtml +='</tr>';  
    return detailsHtml;
}
function suaCbnv(id){
    $("#editcbModal").modal("show");
    $.ajax({
        url:'api/Cbnv/'+ id,
        type: "GET",
        success:function(data){
            console.log(data);
            $("#EditTentinh").val(data.maCBNV);
            $("#edit").html('<button onclick="saveclick1('+id+')" type="button" class="btn btn-default" data-dismiss="modal">Lưu lại</button><button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>');
        }
    })
}
function chitietCbnv(id){
    $("#detaicblModal").modal("show");
    $.ajax({
        url:'api/Cbnv/Detail/'+ id,
        type: "GET",
        success:function(data){
            for(i=0;i<data.length;i++){
            console.log(data[i]);
            $("#detailma").val(data[i].maCBNV);
            $("#detailho").val(data[i].hoCBNV +''+data[i].tenCBNV);
            $("#detailns").val(convertDatetime(data[i].ntns));
            $("#detailphai").val(data[i].phai);
            $("#detailcv").val(data[i].tenChucVu);
            $("#detailtdv").val(data[i].tenDonVi);
            $("#detailhv").val(data[i].hocVi);
            $("#detailsdt").val(data[i].dienThoai);
            $("#detaildc").val(data[i].diaChi);
            $("#edit1").html('<button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>');
        }
        }
    })
}
function themCbnv(id){
    $('#tentinh').val('');
    $("#addcbModal").modal("show");
}