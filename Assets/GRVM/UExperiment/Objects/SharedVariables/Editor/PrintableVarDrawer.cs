
using System;
using UnityEditor;
using UnityEngine;

namespace GRVM.UExperiment.Objects.SharedVariables.Editor
{
    [CustomPropertyDrawer(typeof(PrintableVar))]
    public class PrintableVarDrawer : UnityEditor.PropertyDrawer
    {
        SerializedProperty baseProperty;
        SerializedProperty typeProperty;
        SerializedProperty labelProperty;

        //Var Properties
        SerializedProperty floatProperty;
        SerializedProperty intProperty;
        SerializedProperty stringProperty;




        void UpdateProperties(SerializedProperty main)
        {
            baseProperty = main;
            typeProperty = baseProperty.FindPropertyRelative("type");
            labelProperty = baseProperty.FindPropertyRelative("label");

            floatProperty = baseProperty.FindPropertyRelative("floatVar");
            intProperty = baseProperty.FindPropertyRelative("intVar");
            stringProperty = baseProperty.FindPropertyRelative("stringVar");
        }




        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property != baseProperty)
                UpdateProperties(property);

            return EditorGUI.GetPropertyHeight(typeProperty)
                + EditorGUI.GetPropertyHeight(labelProperty)
                + EditorGUI.GetPropertyHeight(CurrentVarProperty);
        }


        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property != baseProperty)
                UpdateProperties(property);

            var firstRect = new Rect(position.position,
                new Vector2(position.width, EditorGUIUtility.singleLineHeight));
            var secondRect = new Rect(position.position + new Vector2(0, firstRect.height),
                new Vector2(position.width, EditorGUIUtility.singleLineHeight));
            var thirdRect = new Rect(secondRect.position + new Vector2(0, secondRect.height),
                new Vector2(position.width, EditorGUIUtility.singleLineHeight));




            EditorGUI.PropertyField(firstRect, labelProperty);

            EditorGUI.PropertyField(secondRect, typeProperty);
            
            EditorGUI.PropertyField(thirdRect, CurrentVarProperty);
        }

        private SerializedProperty CurrentVarProperty
        {
            get
            {
                var type = (PrintableVar.DataType)typeProperty.intValue;
                switch (type)
                {
                    case PrintableVar.DataType.Float:
                        return floatProperty;
                    case PrintableVar.DataType.Integer:
                        return intProperty;
                    case PrintableVar.DataType.String:
                        return stringProperty;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}