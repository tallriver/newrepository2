<template>
  <div>
    <el-form ref="form" :model="form" label-width="80px">
      <el-form-item>
        <el-cascader
          v-model="form.parentId"
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
        <el-button type="primary" @click="upd">修改菜单</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
export default {
  props: ["updfrom"],
  data() {
    return {
      options: [],
      form: {
        menuId: "",
        menuName: "",
        linkUrl: "",
        parentId: "",
      },
      dmitfrom: this.updfrom,
    };
  },
  methods: {
    getmenu() {
      let backfrom = this.updfrom;
      this.form.menuName = backfrom.menuName;
      this.form.linkUrl = backfrom.linkUrl;
      this.form.menuId = backfrom.menuId;
      this.form.parentId = backfrom.menuId;
    },
    getlist() {
      this.$axios.get("Menu/GetList").then((d) => {
        var reg = new RegExp('\\,"children":\\[]', "g");
        this.options = JSON.parse(JSON.stringify(d.data).replace(reg, ""));
      });
    },
    upd() {
      this.form.parentId =
        this.$refs["tree"].checkedValue[
          this.$refs["tree"].checkedValue.length - 1
        ];
      debugger;

      this.$axios.post("Menu/UpdMenu", this.form).then((d) => {
        if (d.data) {
          this.$message.success("修改成功");
          this.$emit("updtable", true);
        }
      });
    },
  },
  created() {
    this.getlist();
    this.getmenu();
  },
  watch: {
    updfrom(val) {
      this.getlist();
      this.getmenu();
    },
  },
};
</script>