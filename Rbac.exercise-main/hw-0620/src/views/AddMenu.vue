<template>
  <div>
    <el-form ref="form" :model="form" label-width="80px">
      <el-form-item>
        <el-cascader
          :options="options"
          :props="{ checkStrictly: true }"
          clearable
          placeholder="父菜单等级"
          ref="tree"
        ></el-cascader>
      </el-form-item>
      <el-form-item>
        <el-input v-model="form.menuName" placeholder="菜单名称"></el-input>
      </el-form-item>
      <el-form-item>
        <el-input v-model="form.linkUrl" placeholder="链接名称"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="add">添加菜单</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      options: [],
      form: {
        menuName: "",
        linkUrl: "",
        ParentId: 0,
      },
    };
  },
  methods: {
    getlist() {
      this.$axios.get("Menu/GetList").then((d) => {
        var reg = new RegExp('\\,"children":\\[]', "g");
        this.options = JSON.parse(JSON.stringify(d.data).replace(reg, ""));
      });
    },
    add() {
      this.form.ParentId =
        this.$refs["tree"].checkedValue[
          this.$refs["tree"].checkedValue.length - 1
        ];
      debugger;
      this.$axios.post("Menu/AddMenu", this.form).then((d) => {
        if (d.data) {
          this.$message.success("添加成功");
          this.$emit("addtable", true);
        }
      });
    },
  },
  created() {
    this.getlist();
  },
};
</script>