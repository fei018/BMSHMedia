import{r as t,c as s,h as e}from"./p-ee0b9025.js";import{S as i}from"./p-c74b54ba.js";import{p as o}from"./p-971980b1.js";import{T as a}from"./p-37df3757.js";import{g as r}from"./p-0d994806.js";import"./p-a3b5bd35.js";import"./p-80de33dc.js";import"./p-83f217d4.js";import"./p-a3e4386d.js";import"./p-4745c03b.js";import"./p-93cac3a6.js";import"./p-d88cb309.js";import"./p-82db2ff5.js";import"./p-949334ec.js";let p=class{constructor(e){t(this,e),this.valueChange=s(this,"valueChange",7),this.selectList={items:[],isFlagsEnum:!1}}async componentWillLoad(){this.currentValue=this.propertyModel.expressions[i.Json]||"[]"}onValueChanged(e){const t=e.map((e=>"string"==typeof e?e:"number"==typeof e||"boolean"==typeof e?e.toString():e.value));this.valueChange.emit(e),this.currentValue=JSON.stringify(t),this.propertyModel.expressions[i.Json]=this.currentValue}onDefaultSyntaxValueChanged(e){this.currentValue=e.detail}createKeyValueOptions(e){return null===e?e:e.map((e=>"string"==typeof e?{text:e,value:e}:e))}async componentWillRender(){this.selectList=await r(this.serverUrl,this.propertyDescriptor)}render(){const t=this.propertyDescriptor,s=this.propertyModel,r=t.name,i=r,a=r,p=o(this.currentValue),n=this.selectList.items,l=!!t.options&&Array.isArray(t.options)&&t.options.length>0,d=this.createKeyValueOptions(n),u=l?e("elsa-input-tags-dropdown",{dropdownValues:d,values:p,fieldId:i,fieldName:a,onValueChanged:e=>this.onValueChanged(e.detail)}):e("elsa-input-tags",{values:p,fieldId:i,fieldName:a,onValueChanged:e=>this.onValueChanged(e.detail)});return e("elsa-property-editor",{activityModel:this.activityModel,propertyDescriptor:t,propertyModel:s,onDefaultSyntaxValueChanged:e=>this.onDefaultSyntaxValueChanged(e),"single-line":!0},u)}};a.injectProps(p,["serverUrl"]);export{p as elsa_multi_text_property};