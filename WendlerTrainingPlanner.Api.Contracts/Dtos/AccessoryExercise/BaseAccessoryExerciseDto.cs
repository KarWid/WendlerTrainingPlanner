namespace WendlerTrainingPlanner.Api.Contracts.Dtos.AccessoryExercise
{
    using System.Runtime.Serialization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    [KnownType(typeof(AccessoryExerciseDto))]
    [KnownType(typeof(SuperseriesAccessoryExerciseDto))]
    [JsonConverter(typeof(BaseAccessoryExerciseConverter))]
    public abstract record BaseAccessoryExerciseDto(int OrderNumber, int Sets);

    public class BaseAccessoryExerciseConverter : JsonConverter<BaseAccessoryExerciseDto>
    {
        private enum TypeDiscriminator
        {
            BaseAccessoryExerciseDto = 0,
            AccessoryExerciseDto = 1,
            SuperseriesAccessoryExerciseDto = 2
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(BaseAccessoryExerciseDto).IsAssignableFrom(typeToConvert);
        }

        public override BaseAccessoryExerciseDto? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.PropertyName || reader.GetString() != "TypeDiscriminator")
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            BaseAccessoryExerciseDto? result;
            TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetUInt32();

            switch (typeDiscriminator)
            {
                case TypeDiscriminator.AccessoryExerciseDto:
                    ValidateReader(ref reader);
                    result = (AccessoryExerciseDto?)JsonSerializer.Deserialize(ref reader, typeof(AccessoryExerciseDto));
                    break;
                case TypeDiscriminator.SuperseriesAccessoryExerciseDto:
                    ValidateReader(ref reader);
                    result = (SuperseriesAccessoryExerciseDto?)JsonSerializer.Deserialize(ref reader, typeof(SuperseriesAccessoryExerciseDto));
                    break;
                default:
                    throw new NotSupportedException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, BaseAccessoryExerciseDto value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is AccessoryExerciseDto accessoryExerciseDto)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.AccessoryExerciseDto);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, accessoryExerciseDto);
            }
            else if (value is SuperseriesAccessoryExerciseDto superseriesAccessoryExerciseDto)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.SuperseriesAccessoryExerciseDto);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, superseriesAccessoryExerciseDto);
            }
            else
            {
                throw new NotSupportedException();
            }

            writer.WriteEndObject();
        }

        private void ValidateReader(ref Utf8JsonReader reader)
        {
            if (!reader.Read() || reader.GetString() != "TypeValue")
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
        }

        /// <summary>
        /// Get sub-type via KnownTypeAttributes
        /// </summary>
        /// <param name="derivedTypeName">The target type name which corosponds to the discriminator</param>
        private Type GetSubType(TypeDiscriminator derivedTypeName, Type baseType)
        {
            var knownTypes = baseType.GetCustomAttributes(false).Where(ca => ca.GetType().Name == "KnownTypeAttribute").ToList();

            if (knownTypes == null || knownTypes.Count == 0)
                throw new Exception(
                    string.Format("Couldn't find any KnownAttributes over the base {0}. Please define at least one KnownTypeAttribute to determine the sub-type", baseType.Name));


            var x = derivedTypeName.ToString().ToLower();
            foreach (dynamic type in knownTypes)
            {
                if (type.Type != null && type.Type.Name.ToLower() == derivedTypeName.ToString().ToLower())
                    return type.Type;
            }

            throw new Exception(string.Format("Discriminator '{0}' doesn't match any of the defined sub-types via KnownTypeAttributes", derivedTypeName));
        }
    }
}
