<template>
  <div>
    <div style="float: left">
      <el-button type="primary" @click="add">添加菜单</el-button>
    </div>
    <el-table
      :data="tableData"
      style="width: 100%; margin-bottom: 20px"
      row-key="menuId"
      border
      default-expand-all
      :tree-props="{ children: 'children', hasChildren: 'hasChildren' }"
    >
      <el-table-column prop="menuId" label="菜单编号"> </el-table-column>
      <el-table-column prop="menuName" label="名称"> </el-table-column>
      <el-table-column prop="linkUrl" label="链接"> </el-table-column>
      <el-table-column label="操作">
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)"
            >编辑</el-button
          >
          <el-button
            size="mini"
            type="danger"
            @click="handleDelete(scope.$index, scope.row)"
            >删除</el-button
          >
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="添加菜单" :visible.sync="addmenutable" width="30%">
      <Add @addtable="addtable" />
    </el-dialog>
    <el-dialog title="修改菜单" :visible.sync="updmenutable" width="30%">
      <Upd @updtable="updtable" :updfrom="form" />
    </el-dialog>
  </div>
</template>
<script>
import Add from "@/views/AddMenu.vue";
import Upd from "@/views/UpdMenu.vue";
export default {
  components: {
    Add,
    Upd,
  },
  data() {
    return {
      tableData: [],
      addmenutable: false,
      updmenutable: false,
      form: {
        tableData: [],
        menuId: "",
        menuName: "",
        linkUrl: "",
      },
      username: "",
    };
  },
  methods: {
    getmenu() {
      this.$axios.get("Menu/GetMenuAll").then((d) => {
        this.tableData = d.data;
      });
    },
    //弹框添加菜单信息
    add() {
      this.addmenutable = true;
    },
    addtable(val) {
      this.addmenutable = !val;
      this.getmenu();
    },
    //弹框修改菜单信息
    handleEdit(index, row) {
      this.updmenutable = true;
      this.form = row;
      this.form.tableData = this.tableData;
    },
    updtable(val) {
      this.updmenutable = !val;
      this.getmenu();
    },
    handleDelete(index, row) {
      this.$axios.get("Menu/GetMenuById?id=" + row.menuId).then((d) => {
        if (d.data != "") {
          this.$message.error("该菜单存在子节点，不能删除");
          return;
        } else {
          this.$confirm("确定要删除该菜单吗?", "提示", {
            confirmButtonText: "确定",
            cancelButtonText: "取消",
            type: "warning",
          })
            .then(() => {
              this.$axios.delete("Menu/DelMenu?id=" + row.menuId).then((d) => {
                if (d.data) {
                  this.$message.success("删除成功");
                  this.getmenu();
                } else {
                  this.$message.error("删除失败");
                }
              });
            })
            .catch(() => {
              this.$message({
                type: "info",
                message: "已取消删除",
              });
            });
        }
      });
    },
  },
  created() {
    this.getmenu();
  },
};
</script>