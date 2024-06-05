namespace Il2CppInterop.Bindings.Generator;

// Lightweight-ish C++ headers representation for cross-version analysis so we can dispose of clang to hopefully save some ram
public record Il2CppVersion(int MetadataVersion, List<Il2CppVersion.Function> Functions, List<Il2CppVersion.Struct> Structs)
{
    public record Function(string Name, string ReturnType, List<Function.Parameter> Parameters)
    {
        public record Parameter(string Name, string Type);

        public virtual bool Equals(Function? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && ReturnType.Equals(other.ReturnType) && Parameters.SequenceEqual(other.Parameters);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ReturnType, Parameters);
        }
    }

    public record Struct(string Name, List<Struct.Field> Fields)
    {
        public record Field(string Name, string Type);

        public record BitField(string Name, string Type, uint Start, int Width) : Field(Name, Type);

        public virtual bool Equals(Struct? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Fields.SequenceEqual(other.Fields);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Fields);
        }
    }
}
