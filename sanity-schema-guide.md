# Sanity Content Modeling Guidelines

Follow these guidelines when generating schemas for Sanity CMS.

## Document Definition Rules
1. Define a clear `name`, `title`, and `type`.
2. Keep array fields clean using well-defined item types.
3. Make use of references for parent-child relationships instead of nesting deep objects.

## Schema Example
```json
{
  "name": "blogPost",
  "title": "Blog Post",
  "type": "document",
  "fields": [
    { "name": "title", "type": "string", "validation": "Rule => Rule.required()" },
    { "name": "slug", "type": "slug", "options": { "source": "title" } }
  ]
}
```


<!-- version: 2.0.0 -->

# Updates
- Major upgrade with state preservation & advanced MCP tools.