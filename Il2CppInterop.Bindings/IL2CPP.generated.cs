// <auto-generated>

using System.Runtime.InteropServices;
using Il2CppInterop.Bindings.Structs;

namespace Il2CppInterop.Bindings;

public static unsafe class IL2CPP
{
    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_shutdown();

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_config_dir([MarshalAs(UnmanagedType.LPUTF8Str)] string config_path);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_data_dir([MarshalAs(UnmanagedType.LPUTF8Str)] string data_path);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_commandline_arguments(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPUTF8Str)] string[] argv, [MarshalAs(UnmanagedType.LPUTF8Str)] string basedir);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_memory_callbacks(Il2CppMemoryCallbacks* callbacks);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppImage* il2cpp_get_corlib();

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_add_internal_call([MarshalAs(UnmanagedType.LPUTF8Str)] string name, void* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_resolve_icall([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_alloc(nuint size);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_free(void* ptr);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_array_class_get(Il2CppClass* element_class, uint rank);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_array_length(void* array);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_array_get_byte_length(void* array);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_array_new(Il2CppClass* elementTypeInfo, int length);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_array_new_specific(Il2CppClass* arrayTypeInfo, int length);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_array_new_full(Il2CppClass* array_class, int* lengths, int* lower_bounds);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_bounded_array_class_get(Il2CppClass* element_class, uint rank, bool bounded);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_array_element_size(Il2CppClass* array_class);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppImage* il2cpp_assembly_get_image(Il2CppAssembly* assembly);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppType* il2cpp_class_enum_basetype(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_generic(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_inflated(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_assignable_from(Il2CppClass* klass, Il2CppClass* oklass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_subclass_of(Il2CppClass* klass, Il2CppClass* klassc, bool check_interfaces);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_has_parent(Il2CppClass* klass, Il2CppClass* klassc);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_from_il2cpp_type(Il2CppType* type);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_from_name(Il2CppImage* image, [MarshalAs(UnmanagedType.LPUTF8Str)] string namespaze, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_from_system_type(Il2CppReflectionType* type);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_get_element_class(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern EventInfo* il2cpp_class_get_events(Il2CppClass* klass, void** iter);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern FieldInfo* il2cpp_class_get_fields(Il2CppClass* klass, void** iter);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_get_interfaces(Il2CppClass* klass, void** iter);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern PropertyInfo* il2cpp_class_get_properties(Il2CppClass* klass, void** iter);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern PropertyInfo* il2cpp_class_get_property_from_name(Il2CppClass* klass, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern FieldInfo* il2cpp_class_get_field_from_name(Il2CppClass* klass, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern MethodInfo* il2cpp_class_get_methods(Il2CppClass* klass, void** iter);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern MethodInfo* il2cpp_class_get_method_from_name(Il2CppClass* klass, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int argsCount);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_class_get_name(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_class_get_namespace(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_get_parent(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_get_declaring_type(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_class_instance_size(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern nuint il2cpp_class_num_fields(Il2CppClass* enumKlass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_valuetype(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_class_value_size(Il2CppClass* klass, uint* align);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_class_get_flags(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_abstract(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_interface(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_class_array_element_size(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_from_type(Il2CppType* type);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppType* il2cpp_class_get_type(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_has_attribute(Il2CppClass* klass, Il2CppClass* attr_class);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_has_references(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_enum(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppImage* il2cpp_class_get_image(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_class_get_assemblyname(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern nuint il2cpp_class_get_bitmap_size(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_class_get_bitmap(Il2CppClass* klass, nuint* bitmap);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppDomain* il2cpp_domain_get();

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppAssembly* il2cpp_domain_assembly_open(Il2CppDomain* domain, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppAssembly** il2cpp_domain_get_assemblies(Il2CppDomain* domain, nuint* size);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_raise_exception(Il2CppException* ex);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppException* il2cpp_exception_from_name_msg(Il2CppImage* image, [MarshalAs(UnmanagedType.LPUTF8Str)] string name_space, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppException* il2cpp_get_exception_argument_null([MarshalAs(UnmanagedType.LPUTF8Str)] string arg);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_format_exception(Il2CppException* ex, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, int message_size);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_format_stack_trace(Il2CppException* ex, [MarshalAs(UnmanagedType.LPUTF8Str)] string output, int output_size);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_unhandled_exception(Il2CppException* ex);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_field_get_flags(FieldInfo* field);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_field_get_name(FieldInfo* field);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_field_get_parent(FieldInfo* field);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern nuint il2cpp_field_get_offset(FieldInfo* field);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppType* il2cpp_field_get_type(FieldInfo* field);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_field_get_value(Il2CppObject* obj, FieldInfo* field, void* value);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_field_get_value_object(FieldInfo* field, Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_field_has_attribute(FieldInfo* field, Il2CppClass* attr_class);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_field_set_value(Il2CppObject* obj, FieldInfo* field, void* value);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_field_static_get_value(FieldInfo* field, void* value);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_field_static_set_value(FieldInfo* field, void* value);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_collect(int maxGenerations);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern long il2cpp_gc_get_used_size();

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern long il2cpp_gc_get_heap_size();

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_gchandle_new(Il2CppObject* obj, bool pinned);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_gchandle_new_weakref(Il2CppObject* obj, bool track_resurrection);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_gchandle_get_target(uint gchandle);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gchandle_free(uint gchandle);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppType* il2cpp_method_get_return_type(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_method_get_declaring_type(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_method_get_name(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppReflectionMethod* il2cpp_method_get_object(MethodInfo* method, Il2CppClass* refclass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_method_is_generic(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_method_is_inflated(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_method_is_instance(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_method_get_param_count(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppType* il2cpp_method_get_param(MethodInfo* method, uint index);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_method_get_class(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_method_has_attribute(MethodInfo* method, Il2CppClass* attr_class);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_method_get_flags(MethodInfo* method, uint* iflags);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_method_get_token(MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_method_get_param_name(MethodInfo* method, uint index);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_property_get_flags(PropertyInfo* prop);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern MethodInfo* il2cpp_property_get_get_method(PropertyInfo* prop);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern MethodInfo* il2cpp_property_get_set_method(PropertyInfo* prop);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_property_get_name(PropertyInfo* prop);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_property_get_parent(PropertyInfo* prop);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_object_get_class(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_object_get_size(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern MethodInfo* il2cpp_object_get_virtual_method(Il2CppObject* obj, MethodInfo* method);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_object_new(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_object_unbox(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_value_box(Il2CppClass* klass, void* data);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_monitor_enter(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_monitor_try_enter(Il2CppObject* obj, uint timeout);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_monitor_exit(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_monitor_pulse(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_monitor_pulse_all(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_monitor_wait(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_monitor_try_wait(Il2CppObject* obj, uint timeout);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_runtime_invoke(MethodInfo* method, void* obj, void** @params, Il2CppObject** exc);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_runtime_invoke_convert_args(MethodInfo* method, void* obj, Il2CppObject** @params, int paramCount, Il2CppObject** exc);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_runtime_class_init(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_runtime_object_init(Il2CppObject* obj);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_runtime_object_init_exception(Il2CppObject* obj, Il2CppObject** exc);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_runtime_unhandled_exception_policy_set(uint value);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_string_length(Il2CppString* str);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern ushort* il2cpp_string_chars(Il2CppString* str);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppString* il2cpp_string_new([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppString* il2cpp_string_new_len([MarshalAs(UnmanagedType.LPUTF8Str)] string str, uint length);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppString* il2cpp_string_new_utf16([MarshalAs(UnmanagedType.LPWStr)] string text, int len);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppString* il2cpp_string_new_wrapper([MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppString* il2cpp_string_intern(Il2CppString* str);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppString* il2cpp_string_is_interned(Il2CppString* str);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppThread* il2cpp_thread_current();

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppThread* il2cpp_thread_attach(Il2CppDomain* domain);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_thread_detach(Il2CppThread* thread);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppThread** il2cpp_thread_get_all_attached_threads(nuint* size);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_is_vm_thread(Il2CppThread* thread);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_current_thread_walk_frame_stack(void* func, void* user_data);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_thread_walk_frame_stack(Il2CppThread* thread, void* func, void* user_data);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_current_thread_get_top_frame(Il2CppStackFrameInfo* frame);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_thread_get_top_frame(Il2CppThread* thread, Il2CppStackFrameInfo* frame);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_current_thread_get_frame_at(int offset, Il2CppStackFrameInfo* frame);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_thread_get_frame_at(Il2CppThread* thread, int offset, Il2CppStackFrameInfo* frame);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_current_thread_get_stack_depth();

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_thread_get_stack_depth(Il2CppThread* thread);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_type_get_object(Il2CppType* type);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_type_get_type(Il2CppType* type);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_type_get_class_or_element_class(Il2CppType* type);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_type_get_name(Il2CppType* type);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppAssembly* il2cpp_image_get_assembly(Il2CppImage* image);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_image_get_name(Il2CppImage* image);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_image_get_filename(Il2CppImage* image);

    [ApplicableToUnityVersionsSince("5.2.2")]
    [DllImport("GameAssembly")]
    public static extern MethodInfo* il2cpp_image_get_entry_point(Il2CppImage* image);

    [ApplicableToUnityVersionsSince("5.3.2")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_class_get_nested_types(Il2CppClass* klass, void** iter);

    [ApplicableToUnityVersionsSince("5.3.5")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_gc_collect_a_little();

    [ApplicableToUnityVersionsSince("5.3.5")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_disable();

    [ApplicableToUnityVersionsSince("5.3.5")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_enable();

    [ApplicableToUnityVersionsSince("5.5.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_commandline_arguments_utf16(int argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] argv, [MarshalAs(UnmanagedType.LPUTF8Str)] string basedir);

    [ApplicableToUnityVersionsSince("5.5.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_config_utf16([MarshalAs(UnmanagedType.LPWStr)] string executablePath);

    [ApplicableToUnityVersionsSince("5.5.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_config([MarshalAs(UnmanagedType.LPUTF8Str)] string executablePath);

    [ApplicableToUnityVersionsSince("5.6.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_field_set_value_object(Il2CppObject* instance, FieldInfo* field, Il2CppObject* value);

    [ApplicableToUnityVersionsSince("5.6.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_register_log_callback(void* method);

    [ApplicableToUnityVersionsSince("2017.1.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_temp_dir([MarshalAs(UnmanagedType.LPUTF8Str)] string temp_path);

    [ApplicableToUnityVersionsSince("2017.1.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_class_is_blittable(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("2018.1.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_class_get_type_token(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("2018.1.0")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_class_get_rank(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("2018.1.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_type_is_byref(Il2CppType* type);

    [ApplicableToUnityVersionsSince("2018.1.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_type_equals(Il2CppType* type, Il2CppType* otherType);

    [ApplicableToUnityVersionsSince("2018.2.0")]
    [DllImport("GameAssembly")]
    public static extern MethodInfo* il2cpp_method_get_from_reflection(Il2CppReflectionMethod* method);

    [ApplicableToUnityVersionsSince("2018.2.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_type_get_attrs(Il2CppType* type);

    [ApplicableToUnityVersionsSince("2018.2.0")]
    [DllImport("GameAssembly")]
    public static extern byte* il2cpp_type_get_assembly_qualified_name(Il2CppType* type);

    [ApplicableToUnityVersionsSince("2018.2.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_is_debugger_attached();

    [ApplicableToUnityVersionsSince("2018.2.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_unity_install_unitytls_interface(void* unitytlsInterfaceStruct);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_gc_is_disabled();

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_wbarrier_set_field(Il2CppObject* obj, void** targetAddress, void* @object);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern nuint il2cpp_image_get_class_count(Il2CppImage* image);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern Il2CppClass* il2cpp_image_get_class(Il2CppImage* image, nuint index);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern Il2CppCustomAttrInfo* il2cpp_custom_attrs_from_class(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern Il2CppCustomAttrInfo* il2cpp_custom_attrs_from_method(MethodInfo* method);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern Il2CppObject* il2cpp_custom_attrs_get_attr(Il2CppCustomAttrInfo* ainfo, Il2CppClass* attr_klass);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_custom_attrs_has_attr(Il2CppCustomAttrInfo* ainfo, Il2CppClass* attr_klass);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_custom_attrs_construct(Il2CppCustomAttrInfo* cinfo);

    [ApplicableToUnityVersionsSince("2018.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_custom_attrs_free(Il2CppCustomAttrInfo* ainfo);

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern long il2cpp_gc_get_max_time_slice_ns();

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_set_max_time_slice_ns(long maxTimeSlice);

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_gc_is_incremental();

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_gc_has_strict_wbarriers();

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_set_external_allocation_tracker(void* func);

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_set_external_wbarrier_tracker(void* func);

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_class_set_userdata(Il2CppClass* klass, void* userdata);

    [ApplicableToUnityVersionsSince("2019.1.0")]
    [DllImport("GameAssembly")]
    public static extern int il2cpp_class_get_userdata_offset();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_class_for_each(void* klassReportFunc, void* userData);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_type_get_name_chunked(Il2CppType* type, void* chunkReportFunc, void* userData);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_class_get_data_size(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_class_get_static_field_data(Il2CppClass* klass);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_field_is_literal(FieldInfo* field);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_foreach_heap(void* func, void* userData);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_stop_gc_world();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_start_gc_world();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gchandle_foreach_get_target(void* func, void* userData);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_object_header_size();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_array_object_header_size();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_offset_of_array_length_in_array_object_header();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_offset_of_array_bounds_in_array_object_header();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern uint il2cpp_allocation_granularity();

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_override_stack_backtrace(void* stackBacktraceFunc);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_type_is_static(Il2CppType* type);

    [ApplicableToUnityVersionsSince("2019.3.0")]
    [DllImport("GameAssembly")]
    public static extern bool il2cpp_type_is_pointer_type(Il2CppType* type);

    [ApplicableToUnityVersionsSince("2019.4.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_set_default_thread_affinity(long affinity_mask);

    [ApplicableToUnityVersionsSince("2020.1.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_native_stack_trace(Il2CppException* ex, ulong** addresses, int* numFrames, [MarshalAs(UnmanagedType.LPUTF8Str)] string imageUUID);

    [ApplicableToUnityVersionsSince("2020.2.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_start_incremental_collection();

    [ApplicableToUnityVersionsSince("2020.2.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_set_mode(uint mode);

    [ApplicableToUnityVersionsSince("2021.2.0")]
    [DllImport("GameAssembly")]
    public static extern void* il2cpp_gc_alloc_fixed(nuint size);

    [ApplicableToUnityVersionsSince("2021.2.0")]
    [DllImport("GameAssembly")]
    public static extern void il2cpp_gc_free_fixed(void* address);

    [ApplicableToUnityVersionsSince("2022.2.0a13")]
    [DllImport("GameAssembly")]
    public static extern Il2CppCustomAttrInfo* il2cpp_custom_attrs_from_field(FieldInfo* field);
}
