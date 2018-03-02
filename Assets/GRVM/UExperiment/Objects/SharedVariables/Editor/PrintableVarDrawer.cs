
using System;
using UnityEditor;
using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables.Editor
{
    [CustomPropertyDrawer(typeof(PrintableVar))]
    public class PrintableVarDrawer : UnityEditor.PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2;
        }

        SerializedProperty property;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            this.property = property;

            var firstRect = new Rect(position.position, 
                new Vector2(position.width, EditorGUIUtility.singleLineHeight));
            var secondRect = new Rect(position.position + new Vector2(0, firstRect.height),
                new Vector2(position.width, EditorGUIUtility.singleLineHeight));

            var typeProperty = property.FindPropertyRelative("type");
            
            EditorGUI.PropertyField(firstRect, typeProperty);

            var type = (PrintableVar.DataType)typeProperty.intValue;

            SerializedProperty variableProperty = PropertyOfType(type);


            EditorGUI.PropertyField(secondRect, variableProperty);
        }

        private SerializedProperty PropertyOfType(PrintableVar.DataType type)
        {
            switch (type)
            {
                case PrintableVar.DataType.Float:
                    return property.FindPropertyRelative("floatVar");
                case PrintableVar.DataType.Integer:
                    return property.FindPropertyRelative("intVar");
                default:
                    throw new NotImplementedException();
            }
        }
    }
}