namespace Il2CppInterop.Bindings;

public static class Il2CppGC
{
    public static void Collect(int maxGenerations) => Il2CppImports.il2cpp_gc_collect(maxGenerations);

    public static long UsedHeapSize => Il2CppImports.il2cpp_gc_get_used_size();

    public static long AllocatedHeapSize => Il2CppImports.il2cpp_gc_get_heap_size();
}
